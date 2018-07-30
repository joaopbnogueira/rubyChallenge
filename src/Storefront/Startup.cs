using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AutoMapper;
using Cabify.DataRepository;
using Cabify.Storefront.Configuration;
using Cabify.Storefront.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Robotify.AspNetCore;

namespace Cabify.Storefront
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        private IHostingEnvironment Environment { get; }
        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRobotify();
            services.AddMiniProfiler().AddEntityFramework();
            services.AddAutoMapper(typeof(Startup));

            services.UseDataRepository(Configuration.GetConnectionString("DefaultConnection"));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserContext, UserContext>();
            

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/signin");
                })
                .AddOpenIdConnect(options =>
                {
                    var openIdConfig = Configuration.GetSection(nameof(OpenIdConfiguration)).Get<OpenIdConfiguration>();

                    options.ClientId = openIdConfig.ClientId;
                    options.ClientSecret = openIdConfig.ClientSecret;
                    options.Authority = openIdConfig.Authority;
                    
                    options.RequireHttpsMetadata = !Environment.IsDevelopment();
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    // Use the authorization code flow.
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;
                    options.ClaimActions.MapAllExcept("aud", "iss", "iat", "nbf", "exp", "aio", "c_hash", "uti", "nonce");
                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("email");
                    options.Scope.Add("profile");

                    options.Events = new OpenIdConnectEvents
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.HandleResponse();

                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            if (Environment.IsDevelopment())
                            {
                                // Debug only, in production do not share exceptions with the remote host.
                                return c.Response.WriteAsync(c.Exception.ToString());
                            }
                            return c.Response.WriteAsync("An error occurred processing your authentication.");
                        },

                        OnTicketReceived = context =>
                        {
                            context.Properties.AllowRefresh = true;
                            return Task.CompletedTask;
                        },

                        OnRedirectToIdentityProviderForSignOut = context =>
                        {
                            var logoutUri = openIdConfig.LogoutUri;
                            var postLogoutUri = context.Properties.RedirectUri;
                            if (!string.IsNullOrEmpty(postLogoutUri))
                            {
                                if (postLogoutUri.StartsWith("/"))
                                {
                                    // transform to absolute
                                    var request = context.Request;
                                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                                }
                                logoutUri = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(openIdConfig.LogoutUri, "returnTo", postLogoutUri);
                            }

                            context.Response.Redirect(logoutUri);
                            context.HandleResponse();

                            return Task.CompletedTask;
                        }
                    };
                });            

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
                //options.Filters.Add(typeof(DbContextTransactionPageFilter));
                //options.Filters.Add(typeof(ValidatorPageFilter));
                //options.ModelBinderProviders.Insert(0, new EntityModelBinderProvider());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<Startup>(); });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.ApplicationServices.InitializeDataRepository();

            app.UseHttpsRedirection();

            app.UseStaticFiles();            
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseRobotify();
        }
    }
}

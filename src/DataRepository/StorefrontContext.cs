﻿using Cabify.DataRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace Cabify.DataRepository
{
    internal class StorefrontContext: DbContext
    {
        public StorefrontContext(DbContextOptions<StorefrontContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

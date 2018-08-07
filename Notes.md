
## General Notes

Vanilla .Net Core MVC solution with 3 main components
 - Frontend React App
 - Backend exposed through authenticated API
 - SQL Database
 - Code published to [GitHub](https://github.com/joaopbnogueira/rubyChallenge) & integrated with AppVeyor for CI

## Frontend Notes
Things done:
 - React + Typescript + Webpack
 - Application logic works as specified

Things left out:
 - Debouncing (button) events - e.g. using reactive event streams /
   redux-cycles and similar libraries
 - Several UI/UX improvements. Examples include:
	  1) follow cabify design-guidelines
	  2) partial/overlay loaders
 - Sass support
 - Unit/functional testing - definitely a MUST have
 - Code splitting
 - Server side rendering
 - Versioning
 - Improved package.json scripts / webpack configuration
- Translations + Localization (currency, format, etc)

## Backend Notes
Things done:
 - Asp .Net Core / MVC / WebApi
 - Auth with OpenIDConnect supporting Google and Facebook SSO - (using Auth0's free services)
 - Flexible logging with Serilog
 - Automapper to easily map between domain boarders without having to manually map DTOs
 - Fluentvalidation to validate API requests
- EntityFramework
- Application logic works as specified

Things left out:
- Translations + Localization (currency, format, etc)
- Versioning
- Additional Unit, Integration & Performance tests
- Scalability concerns 
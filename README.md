
# Cabify Mobile Challenge

![MIT license](http://img.shields.io/badge/license-MIT-brightgreen.svg) ![Windows build status](https://ci.appveyor.com/api/projects/status/0cphy1ydaplprp1o/branch/master?svg=true)

## General Notes

App available here: https://joaopbnogueira.azurewebsites.net/
Source available here: https://github.com/joaopbnogueira/rubyChallenge

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
 -- Note: OID client_secret is in the settings because this is a sandboxed environment, and is included solely for the convenience of app reviewers
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

## Original Challenge
##### Besides providing exceptional transportation services, Cabify also runs a physical store which sells (only) 3 products:

``` 
Code         | Name                |  Price
-------------------------------------------------
VOUCHER      | Cabify Voucher      |   5.00€
TSHIRT       | Cabify T-Shirt      |  20.00€
MUG          | Cafify Coffee Mug   |   7.50€
```

Various departments have insisted on the following discounts:

 * The marketing department believes in 2-for-1 promotions (buy two of the same product, get one free), and would like for there to be a 2-for-1 special on `VOUCHER` items.

 * The CFO insists that the best way to increase sales is with discounts on bulk purchases (buying x or more of a product, the price of that product is reduced), and demands that if you buy 3 or more `TSHIRT` items, the price per unit should be 19.00€.

Cabify's checkout process allows for items to be scanned in any order, and should return the total amount to be paid. The interface for the checkout process looks like this (ruby):

```ruby
co = Checkout.new(pricing_rules)
co.scan("VOUCHER")
co.scan("VOUCHER")
co.scan("TSHIRT")
price = co.total
```

Using ruby (>= 2.0), implement a checkout process that fulfills the requirements.

Examples:

    Items: VOUCHER, TSHIRT, MUG
    Total: 32.50€

    Items: VOUCHER, TSHIRT, VOUCHER
    Total: 25.00€

    Items: TSHIRT, TSHIRT, TSHIRT, VOUCHER, TSHIRT
    Total: 81.00€

    Items: VOUCHER, TSHIRT, VOUCHER, VOUCHER, MUG, TSHIRT, TSHIRT
    Total: 74.50€

**The code should:**
- Be written as production-ready code. You will write production code.
- Be easy to grow and easy to add new functionality.
- Have notes attached, explaining the solution and why certain things are included and others are left out.

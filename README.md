# BasketTest

[![.NET](https://github.com/chrisrichards/BasketTest/actions/workflows/dotnet.yml/badge.svg)](https://github.com/chrisrichards/BasketTest/actions/workflows/dotnet.yml)

Shopping basket technical test

Implemented as a C# class library. The unit tests illustrate the functionality, with the tests in `AcceptanceTests.cs` demonstrating that the code passes the requirements set in the doc.

Limitations:
- doesn't handle adding multiple products of the same type to the basket
- no internationalization
- currency formatting defaults to the current thread culture
- can add multiple OfferVouchers to a basket

Notes:
- GitHub action to build and trun tests setup
- visitor pattern used for voucher descriptions
- could possibly move calculation of the SubTotal into it's own class (as duplicated in Basket and OfferVoucher)

## Build instructions

From the project folder run

`dotnet build`

## Test instructions

From the project folder run

`dotnet test`

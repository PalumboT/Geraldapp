# Welcome to Geraldapp!

Simple app for contacts and skills management.

Using .NET 6 with the following technologies :

- Swagger
- NSwag
- FluentValidation
- Implicite operators
- AutoMapper
- Microsoft.AspNetCore.Mvc

## Todo
- Validation on contact (creation and update)
- Adding authorization and authentication

## Improvements
- Abstraction of the contact skill validators
- Split contacts, contact skills and skills domains
- Unit testing
- Integration testing
- Add usage of in memory or server database through a setting
- Reduce code duplication (around entities services and errors)
- Map endpoint DTOs to other DTOs instead of the entites
- Remove FluentValidation from domain
- Improve the way the validation return the errors
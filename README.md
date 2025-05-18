# Finturest Country API C# SDK

[![NuGet](https://img.shields.io/nuget/v/Finturest.Country.svg)](https://www.nuget.org/packages/Finturest.Country)
[![CI](https://github.com/Finturest/finturest-country-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/Finturest/finturest-country-dotnet/actions/workflows/ci.yml)

Official C# SDK for the [Finturest Country API](https://finturest.com/products/country-api) - supports .NET Standard 2.0+ and all modern .NET versions.

## Overview

This SDK offers seamless integration with the Finturest Country API, enabling access to up-to-date and structured data for all countries and territories. It supports .NET Standard 2.0 and later, ensuring compatibility with .NET Core and the latest .NET releases.

## Features

- **Global Coverage**: Provides information on all 249 countries and territories worldwide.

- **Standardized Country Codes**: Supports ISO 3166-1 alpha-2, alpha-3, and numeric codes.

- **Currency & Language Metadata**: Includes official currencies, languages, and region details per country.

- **Geopolitical Details**: Returns data on capitals, time zones, regional blocks, and more.

- **Reliable Data Source**: Aggregated from trusted international standards and regularly updated.

## Installation

Using the [.NET Core command-line interface (CLI) tools](https://learn.microsoft.com/en-us/dotnet/core/tools/):

```sh
dotnet add package Finturest.Country
```

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```sh
nuget install Finturest.Country
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package Finturest.Country
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Finturest.Country".
5. Click on the Finturest.Country package, select the appropriate version in the
   right-tab and click _Install_.

## Usage

### Registering

To use the `Finturest.Country` client, register it in your application's dependency injection container using `AddFinturestCountry`. This configures the services required to communicate with the Finturest Country API.

```C#
var services = new ServiceCollection();

services.AddFinturestCountry(options =>
{
    options.ApiKey = "YOUR_API_KEY";
});
```

> **Note**  
> `ICountryServiceClient` is registered in the DI container and should be resolved via dependency injection.  
> In ASP.NET Core applications, it's recommended to inject it through constructor injection.

> **Note**  
> The abstractions for the Finturest Country API client are provided in a separate package named `Finturest.Country.Abstractions`.  
> You can reference this package in your business layer to avoid a tight dependency on the implementation.  
> Only the root application or composition root should reference the full `Finturest.Country` package that contains the implementation.

### Get countries

To get countries using the Finturest Country API, call the `GetCountriesAsync` method on the `ICountryServiceClient`.

```C#
var serviceProvider = services.BuildServiceProvider();

var countryServiceClient = serviceProvider.GetRequiredService<ICountryServiceClient>();

var result = await countryServiceClient.GetCountriesAsync();

Console.WriteLine($"Countries: {result.Count}.");
```

> **Note**  
> In production applications, avoid using `BuildServiceProvider()` manually.  
> Instead, use constructor injection to get `ICountryServiceClient` from the framework’s dependency injection system.

## Subscription & Pricing

To get access to the Finturest Country API or subscribe to a plan, please visit the subscription page. An active subscription is required to access the API in production.

[Manage subscriptions](https://finturest.com/dashboard/subscriptions)

## API Key Generation

An API key is required to use the SDK and can be generated on your Finturest dashboard:

[Generate API key](https://finturest.com/dashboard/access-tokens)

## Documentation

For full API reference and usage guides, please visit the official Finturest Country API documentation:

[View API reference](https://api.finturest.com/docs/#tag/country)

## Contact

For support, questions, or inquiries, please contact us at: [support@finturest.com](mailto:support@finturest.com)

# SupaTodo

Simple REST API for managing a collection of todo items implemented using ASP.NET Core.

I'm developing this as I learn C#, .NET, and the Domain Driven Design pattern.

## Running the application

You can run the application with the following command:

```sh
dotnet run --project Presentation
```

## Sending requests

Sample requests are found in the Requests folder. The VSCode extension "Rest Client" is recommended to execute these requests.

## Architecture

This project aims to follow the Domain Driven Design pattern. I am currently learning this pattern, so there might be some inconsistencies or things that aren't done correctly.

Domain driven design aims to separate applications into four layers:

- Infrastructure
- Domain
- Application
- Presentation

This application implements the presentation layer as an ASP.NET Core REST api, however it should be possible to implement alternative presentation layers (Razor pages, Blazor, WPF etc) with no modifications to the other layers.

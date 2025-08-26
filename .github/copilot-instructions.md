# GitHub Copilot Instructions - Blazor WebAssembly App (.NET 9)

## Project Overview
This is a Blazor WebAssembly application built with .NET 9. 

it is located on https://github.com/jamesmontemagno/SimplePetApp

The application follows modern best practices for Blazor WASM development.

All code for the frontend is loctated in the MyPetVenues folder

## Coding Standards
- Use C# 12 features where appropriate
- Implement component-based architecture
- Follow SOLID principles
- Use nullable reference types
- Prefer async/await for asynchronous operations

## Blazor WebAssembly Best Practices
- Use app.css for css styles
- Implement proper dependency injection
- Use `IHttpClientFactory` for HTTP requests
- Leverage Blazor's component parameters and cascading parameters
- Use `@key` directive for optimized rendering of lists
- Implement efficient state management
- Use JS interop only when necessary

## Performance Considerations
- Minimize initial download size
- Use lazy loading for routes
- Implement efficient rendering techniques
- Consider using pre-rendering where appropriate
- Implement proper cancellation token handling

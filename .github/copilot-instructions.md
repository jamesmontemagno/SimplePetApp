it is located on https://github.com/jamesmontemagno/SimplePetApp

# GitHub Copilot Instructions – SimplePetApp (Blazor WebAssembly, .NET 9)

## Project Overview

- This is a Blazor WebAssembly app using .NET 9, located in the `MyPetVenues` folder.
- The app is component-based, with all UI and logic in `MyPetVenues/`.
- The entry point is `App.razor`, using `MainLayout.razor` for layout.
- The main page is `Pages/Home.razor`.

## Architecture & Patterns

- **Component Structure:** All UI is in Razor components under `Pages/` and `Layout/`.
- **Styling:** Uses CSS isolation (`.razor.css` files) and global styles in `wwwroot/css/app.css`.
- **Theme Handling:** Light/dark mode is managed via `wwwroot/js/theme.js` (sets `data-theme` on `<html>` and persists in `localStorage`). Update UI or add toggles by calling `window.setTheme('light'|'dark')` via JS interop.
- **HTTP/Data:** Use dependency-injected `HttpClient` for API/data access (`Program.cs`).
- **State:** No global state container; use cascading/component parameters for state sharing.

## Developer Workflows

- **Run the app:** Use the VS Code task "Run Blazor App" or:
	```
	dotnet watch run --project MyPetVenues
	```
- **Hot reload:** Supported via `dotnet watch`.
- **Debugging:** Use browser dev tools; set breakpoints in C# via VS Code.
- **Build output:** Located in `MyPetVenues/bin/Debug/net9.0/`.

## Project Conventions

- Use C# 12 features and nullable reference types.
- Prefer async/await for all async work.
- Use `@key` in Razor for list rendering performance.
- Use JS interop only for browser APIs (e.g., theme switching).
- All static assets (images, JS, CSS) are in `wwwroot/`.

## Integration Points

- **Theme toggle:** Update or debug theme logic in `wwwroot/js/theme.js` and ensure CSS uses `[data-theme]` selectors.
- **External APIs:** Add new services via DI in `Program.cs`.
- **Routing:** Add new pages in `Pages/` and update `App.razor` if needed.

## Examples

- To add a new page: create `Pages/Foo.razor`, add a route, and optionally a `Foo.razor.css`.
- To add a theme toggle: call `window.setTheme('light')` or `window.setTheme('dark')` from a component using JS interop.

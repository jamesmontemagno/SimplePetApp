# GitHub Copilot Instructions - Blazor WebAssembly App (.NET 9)

## Project Overview
This is a Blazor WebAssembly application built with .NET 9. 

it is located on https://github.com/jamesmontemagno/SimplePetApp

The application follows modern best practices for Blazor WASM development.

All code for the frontend is loctated in the MyPetVenues folder

## Branching & Contribution Policy (Enforced)
DO NOT COMMIT DIRECTLY TO `main`.

Required workflow:
1. Create a feature branch using the pattern `feature/<short-topic>` or `fix/<short-topic>` from the latest `origin/main` (never from a detached local main ahead of remote).
2. Make granular commits on the feature branch.
3. Open a Pull Request (PR) targeting `main` with a clear title & summary (what/why, any follow-up steps, screenshots for UI changes).
4. Ensure build & basic manual test pass before marking PR ready.
5. After review & CI success, squash merge (preferred) unless history needs to be preserved.

Automation / Assistant rules:
- If asked to "commit" while on `main`, automatically: (a) create a branch, (b) push branch, (c) open PR instead.
- Never rewrite `main` history (no forced pushes) except explicit owner override instruction.
- Add/update documentation in the same PR when behavior or UI changes.
- Large changes: break into multiple PRs (< ~400 lines diff each) when feasible.

Naming examples:
`feature/landing-page-redesign`, `feature/venue-search`, `fix/dark-mode-toggle`, `chore/update-deps`.

Checklist before opening PR:
- [ ] Build succeeds (`dotnet build`)
- [ ] No obvious console errors at runtime
- [ ] UI changes visually smoke-tested light & dark mode
- [ ] Added/updated comments or docs if needed
- [ ] No stray debug code or TODOs without issue references

Violations: The assistant should refuse direct commits to `main` and instead guide or automatically branch.

## Coding Standards
- Use C# 12 features where appropriate
- Implement component-based architecture
- Follow SOLID principles
- Use nullable reference types
- Prefer async/await for asynchronous operations

## Blazor WebAssembly Best Practices
- Use CSS isolation for components
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

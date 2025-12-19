# SimplePetApp – Product Requirements Document

**Last Updated:** 2025-12-19  
**Vision:** Make it simple for pet parents to discover, evaluate, and share pet-friendly places (cafés, parks, hotels, rentals, shops) with the confidence that their companions are welcome.

## Background & Problem
Pet owners struggle to know which venues truly welcome their animals and what amenities are available (water bowls, off-leash zones, shaded areas, grooming). Existing reviews are scattered or not pet-focused. The app provides a dedicated, pet-first directory with community reviews.

## Objectives & Success Metrics
- Surface trustworthy, pet-specific venue details and amenities.
- Reduce time to find a fitting venue with effective filters.
- Encourage contributions of new venues and reviews.
- **KPIs (for future live release):**
  - Search-to-click rate on a venue detail page.
  - New venue submissions per week.
  - Review submissions per active user.
  - Retention on saved filters / recent searches.

## Target Users & Personas
- **Urban Pet Parent (primary):** Needs quick, reliable recommendations by pet type, amenities, and location.
- **Traveling Pet Owner:** Filters by city and category (hotel, rental, café) and needs clear pet policies.
- **Venue Host (secondary):** Wants accurate listings and fresh reviews to attract pet owners.

## Scope
### In Scope (for current mock-data MVP)
- Landing experience that highlights value and guides to explore or add a venue.
- Venue directory with search + filters (text, category, pet type, amenity).
- Venue detail pages with amenities, pet policies, and community reviews.
- Ability to add venues and add reviews (stored in-memory for now).
- Mock data seed to exercise all flows.

### Out of Scope (future)
- Auth, favorites, real-time moderation, payments, maps/geo search, notifications, offline support.

## User Journeys
1) **Discover:** I want to find a nearby café that allows medium dogs, has shaded seating, and water bowls.  
2) **Evaluate:** I want to read pet-focused reviews and see amenities before deciding.  
3) **Contribute (venue):** I want to add a new park with pet rules and amenities.  
4) **Contribute (review):** I want to share a review with a rating and pet type.

## Functional Requirements
1. **Landing Page**
   - Hero with value prop and CTAs to explore venues and add a venue.
   - Quick search module (text + pet type + amenity) showing immediate matches.
   - Featured venues, recent additions, and “how it works” guidance.

2. **Search & Browse**
   - Directory view with search, category filter, pet-type filter, amenity filter, and clear/reset.
   - Venue cards show name, city/neighborhood, category, rating, and key amenities.

3. **Venue Detail**
   - Hero with image, rating, address/city, category, amenities/pet policy.
   - Reviews list with author, pet type, rating, and comments.
   - Suggested similar venues (same category or city).

4. **Add Venue**
   - Form with validation for: name, category, city, description, pet types, amenities, address/area, image selection, website/contact (optional).
   - On submit, venue is added to the in-memory catalog and discoverable immediately.

5. **Add Review**
   - Form on the venue detail page with rating (1–5), comment, reviewer name, and pet type.
   - Submissions update average rating and review count immediately.

6. **Data & State**
   - Mock data stored client-side; no backend dependency.
   - Amenity and pet type lists are reusable across forms and filters.

## Non-Functional Requirements
- Accessible components (semantic headings, labels, focus states).
- Responsive layout for mobile → desktop.
- Fast interactions using client-side data; avoid blocking calls.
- Clear error/empty states for missing venues or filters with no results.

## Data Model (mock)
- **PetVenue**
  - Id (int), Name, Category, City, Neighborhood, Address, Description
  - PetTypes (list), Amenities (list), Hours, ReservationsRequired (bool)
  - AverageRating (double), ReviewCount (int), ImageUrl, Website, Contact
- **VenueReview**
  - Author, PetType, Rating (1–5), Comment, CreatedAt

## Release Plan
- **M0 (current):** Mock-data Blazor WASM app covering landing, browse, detail, add venue, and add review flows.
- **M1 (future):** Add persistence via API, auth for contributions, moderation workflow, and saved lists/favorites.

## Risks & Open Questions
- Venue accuracy without moderation (mitigated by clear prompts and future verification).
- Regional coverage—needs seeding per market on go-live.
- Map/geo search is deferred; verify if required for next milestone.

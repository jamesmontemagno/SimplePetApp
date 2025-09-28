# Responsive Breakpoints Reference

## Project Breakpoints

This project uses a mobile-first responsive design approach with the following breakpoints:

### Breakpoint Overview

| Breakpoint | Width | Target Devices | Navigation Style |
|------------|-------|----------------|------------------|
| Desktop | >968px | Desktop computers, large laptops | Horizontal nav bar |
| Tablet | 769px - 968px | Tablets in landscape, small laptops | Horizontal nav bar (condensed) |
| Mobile | ≤768px | Tablets in portrait, phones | Hamburger menu |
| Small Mobile | ≤480px | Most smartphones | Hamburger menu (compact) |
| Very Small | ≤360px | Small/older smartphones | Hamburger menu (ultra-compact) |

## CSS Media Query Reference

### In app.css (Global & Navigation)

```css
/* Base styles: Desktop first */
/* Applies to all screen sizes unless overridden */

/* Tablet adjustments */
@media (min-width: 769px) and (max-width: 968px) {
  /* Slightly reduced spacing and font sizes */
}

/* Mobile and below */
@media (max-width: 768px) {
  /* Hamburger menu active */
  /* Stacked layouts */
  /* Full-width navigation */
}

/* Small mobile */
@media (max-width: 480px) {
  /* Further reduced sizes */
  /* Optimized for small screens */
}

/* Very small devices (optional) */
@media (max-width: 360px) {
  /* Ultra-compact mode */
}
```

### In pet-detail.css & venue-detail.css

```css
/* Desktop: >968px (default styles) */

/* Tablet/Mobile */
@media (max-width: 968px) {
  /* Single column layout */
  /* Reduced image heights */
}

/* Small mobile */
@media (max-width: 480px) {
  /* Compact spacing */
  /* Smaller fonts and icons */
}

/* Very small (venue-detail.css only) */
@media (max-width: 360px) {
  /* Minimal spacing */
}
```

## Design Decisions

### Why 768px for mobile breakpoint?
- Standard iPad width in portrait (768px)
- Common threshold in Bootstrap and other frameworks
- Good separation between tablet and phone experiences
- Allows hamburger menu to be useful without being intrusive

### Why 968px for desktop/mobile split on detail pages?
- Gives more breathing room for two-column layouts
- Ensures images and content don't feel cramped
- Accommodates smaller laptop screens better
- Different from navigation breakpoint for layout flexibility

### Why 480px for small mobile?
- Represents typical smartphone width
- iPhone SE, iPhone 6/7/8 size range
- Many Android phones in this range
- Good point for additional optimization

## Component-Specific Breakpoints

### Header/Navigation
```css
Main breakpoint: 768px
- Above: Horizontal navigation
- Below: Hamburger menu dropdown

Secondary: 480px
- Further size reductions
```

### Pet Details Page
```css
Main breakpoint: 968px
- Above: Two-column (image + info)
- Below: Single column stack

Secondary: 480px
- Reduced image height
- Compact spacing
```

### Venue Details Page
```css
Main breakpoint: 968px
- Above: Two-column header, grid amenities
- Below: Stacked layout

Secondary: 480px
- Compact reviews
- Smaller badges

Tertiary: 360px
- Minimal spacing
- Smallest font sizes
```

## Responsive Units Used

### Fixed Units (px)
Used for:
- Border widths (1px, 2px)
- Small specific measurements
- Breakpoint definitions
- Max-widths for content containers

### Relative Units (rem)
Used for:
- Font sizes (scales with root font size)
- Padding and margins (consistent spacing)
- Component sizing

### Percentage (%)
Used for:
- Container widths
- Flexible layouts
- Responsive images

### Viewport Units (vh, vw)
Used for:
- Full-height sections
- Loading containers
- Modal overlays

## Grid Behavior

### Cards Grid (if present)
```css
Desktop: repeat(auto-fill, minmax(320px, 1fr))
Mobile: 1fr (single column)
```

### Amenities Grid
```css
Desktop: repeat(auto-fill, minmax(250px, 1fr))
Mobile: 1fr (single column)
```

### Stats Grid (Pet Details)
```css
Desktop: repeat(auto-fit, minmax(150px, 1fr))
Mobile: 1fr (single column)
```

## Touch Target Sizes

Following WCAG guidelines:

| Element | Desktop Size | Mobile Size | Notes |
|---------|-------------|-------------|-------|
| Nav Links | 44x40px | 48x44px | Adequate padding |
| Buttons | Variable | Min 44x44px | Touch-friendly |
| Hamburger | N/A | 32x24px (but in 44x44px area) | Center aligned |
| Icons | 1.5-2rem | 1.25-1.5rem | Proportional |

## Typography Scale

### Desktop
- H1: 3rem (48px) - 3.5rem (56px)
- H2: 2rem (32px) - 2.5rem (40px)
- H3: 1.75rem (28px)
- Body: 1rem (16px) - 1.125rem (18px)

### Mobile (≤768px)
- H1: 2rem (32px) - 2.5rem (40px)
- H2: 1.5rem (24px) - 2rem (32px)
- H3: 1.375rem (22px)
- Body: 0.938rem (15px) - 1rem (16px)

### Small Mobile (≤480px)
- H1: 1.75rem (28px) - 2rem (32px)
- H2: 1.375rem (22px) - 1.5rem (24px)
- H3: 1.25rem (20px)
- Body: 0.938rem (15px)

## Common Responsive Patterns

### 1. Stack-on-Mobile
```css
.container {
  display: grid;
  grid-template-columns: 1fr 1fr; /* Desktop */
}

@media (max-width: 968px) {
  .container {
    grid-template-columns: 1fr; /* Mobile */
  }
}
```

### 2. Hide-on-Mobile
```css
.desktop-only {
  display: block;
}

@media (max-width: 768px) {
  .desktop-only {
    display: none;
  }
}
```

### 3. Show-on-Mobile
```css
.mobile-only {
  display: none;
}

@media (max-width: 768px) {
  .mobile-only {
    display: block;
  }
}
```

### 4. Responsive Spacing
```css
.section {
  padding: 2rem; /* Desktop */
}

@media (max-width: 768px) {
  .section {
    padding: 1rem; /* Mobile */
  }
}

@media (max-width: 480px) {
  .section {
    padding: 0.75rem; /* Small mobile */
  }
}
```

## Testing Quick Reference

### Browser DevTools Shortcuts
- **Chrome/Edge**: `Ctrl+Shift+M` (Windows) / `Cmd+Shift+M` (Mac)
- **Firefox**: `Ctrl+Shift+M` (Windows) / `Cmd+Option+M` (Mac)

### Common Test Widths
```
320px - Smallest (iPhone SE old)
375px - iPhone SE, 6, 7, 8
390px - iPhone 12, 13, 14
414px - iPhone Plus models
768px - iPad portrait
1024px - iPad landscape
1366px - Small laptop
1920px - Full HD desktop
```

---

**Quick Tip**: When in doubt, test at 375px (mobile), 768px (tablet), and 1440px (desktop)!

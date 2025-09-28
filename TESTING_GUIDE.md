# Visual Testing Guide - Mobile Responsiveness

## Quick Testing Checklist

### Using Browser DevTools

#### Chrome/Edge DevTools:
1. Press `F12` or `Ctrl+Shift+I` (Windows) / `Cmd+Option+I` (Mac)
2. Click the device toggle icon (📱) or press `Ctrl+Shift+M`
3. Select different device presets or enter custom dimensions

#### Recommended Test Dimensions:

```
Desktop:
- 1920x1080 (Full HD)
- 1440x900 (MacBook Pro)
- 1366x768 (Standard laptop)

Tablet:
- 768x1024 (iPad Portrait)
- 1024x768 (iPad Landscape)
- 820x1180 (iPad Air)

Mobile:
- 375x667 (iPhone SE, 8)
- 390x844 (iPhone 12, 13, 14)
- 414x896 (iPhone 11 Pro Max)
- 360x740 (Samsung Galaxy S10)
- 320x568 (iPhone 5/SE - smallest)
```

## Feature Testing Guide

### 1. Navigation Menu (All Pages)

#### Desktop (>768px):
- [ ] Navigation links visible horizontally
- [ ] Hamburger menu NOT visible
- [ ] All nav items fit in one line
- [ ] Hover effects work on nav links
- [ ] Theme toggle visible and functional

#### Mobile (≤768px):
- [ ] Hamburger menu visible (3 horizontal lines)
- [ ] Navigation links hidden by default
- [ ] Click hamburger menu:
  - [ ] Icon animates to X
  - [ ] Navigation drops down from top
  - [ ] Semi-transparent overlay appears
  - [ ] Auth buttons appear in dropdown
- [ ] Click nav link:
  - [ ] Navigates to page
  - [ ] Menu closes automatically
- [ ] Click overlay:
  - [ ] Menu closes
- [ ] Scroll behavior:
  - [ ] Header remains fixed at top

### 2. Pet Details Page

#### Desktop (>968px):
```
Layout: [Image] [Info]
- Pet image on left (400px height)
- Pet info on right
- Stats in 3 columns
- Personality in multiple columns
```

Test:
- [ ] Image displays correctly
- [ ] Pet type icon in corner of image
- [ ] Stats display in grid
- [ ] All text is readable
- [ ] Personality traits in multiple columns

#### Tablet (768px - 968px):
```
Layout: [Image] [Info]
- Slightly smaller fonts
- Stats in fewer columns
```

Test:
- [ ] Layout still works
- [ ] No overflow or cutting
- [ ] Readable text

#### Mobile (≤768px):
```
Layout:
[Image]
[Info]
[Stats - stacked]
[Content]
```

Test:
- [ ] Image takes full width (300px height)
- [ ] Stats stacked vertically
- [ ] Personality traits full width
- [ ] Good spacing between sections
- [ ] Back button easily tappable

#### Small Mobile (≤480px):
- [ ] Image height 250px
- [ ] Smaller pet type icon
- [ ] Reduced padding
- [ ] All text still readable
- [ ] Touch targets at least 44x44px

### 3. Venue Details Page

#### Desktop (>968px):
```
Layout: [Image] [Details]
- Venue image on left
- Details on right
- Amenities in 3+ columns
- Reviews with horizontal headers
```

Test:
- [ ] Two-column header layout
- [ ] Category badge on image
- [ ] Star rating displays correctly
- [ ] Amenities in grid
- [ ] Reviews formatted nicely

#### Mobile (≤768px):
```
Layout:
[Image]
[Details]
[Rating]
[Amenities - stacked]
[Reviews - stacked]
```

Test:
- [ ] Image full width (300px height)
- [ ] All details stacked
- [ ] Amenities one per row
- [ ] Review headers stack vertically
- [ ] Pet policy readable
- [ ] Contact info accessible

#### Small Mobile (≤480px):
- [ ] Image height 250px
- [ ] Category badge smaller
- [ ] Review cards compact
- [ ] All badges properly sized
- [ ] Touch-friendly amenity items

### 4. Common Elements

#### Back Button:
- [ ] Desktop: Adequate padding, hover effect
- [ ] Mobile: Large enough to tap (min 44x44px)
- [ ] Works on all pages

#### Loading States:
- [ ] Spinner visible and centered
- [ ] Animation smooth
- [ ] Text readable

#### Cards (if present):
- [ ] Proper spacing on all devices
- [ ] Images scale correctly
- [ ] Text doesn't overflow
- [ ] Tap targets adequate

## Browser-Specific Testing

### Safari (iOS):
- [ ] Touch interactions work
- [ ] Backdrop-filter supported
- [ ] Animations smooth
- [ ] No rubber-band scrolling issues
- [ ] Safe area insets respected

### Chrome (Android):
- [ ] Address bar hides on scroll
- [ ] Viewport height correct
- [ ] Touch ripple effects
- [ ] Animations smooth

### Firefox:
- [ ] All CSS features work
- [ ] Animations smooth
- [ ] No layout issues

## Performance Testing

### Mobile Network Simulation:
1. In DevTools, go to Network tab
2. Select throttling (e.g., "Fast 3G")
3. Test:
   - [ ] Page loads in reasonable time
   - [ ] Images don't block rendering
   - [ ] Interactions responsive

### Lighthouse Audit:
1. Open DevTools → Lighthouse
2. Select "Mobile" device
3. Run audit
4. Check scores:
   - [ ] Performance > 90
   - [ ] Accessibility > 95
   - [ ] Best Practices > 90

## Touch Interaction Testing

On actual device or touch simulation:

### Tap Targets:
- [ ] All buttons easily tappable
- [ ] Minimum 44x44px tap areas
- [ ] Adequate spacing between tappable elements

### Gestures:
- [ ] Scroll smooth and responsive
- [ ] No horizontal overflow scroll
- [ ] Pinch-zoom disabled where appropriate

### Forms (if applicable):
- [ ] Inputs zoom-friendly
- [ ] Keyboard doesn't cover inputs
- [ ] Submit buttons accessible

## Common Issues to Check

### Layout Issues:
- [ ] No horizontal scrollbar
- [ ] Content doesn't overflow viewport
- [ ] Images scale properly
- [ ] Text wraps appropriately

### Typography:
- [ ] Minimum 16px font size for body text
- [ ] Line height adequate (1.5+)
- [ ] No text too long for width
- [ ] Headings properly sized

### Spacing:
- [ ] Adequate padding on mobile
- [ ] Sections clearly separated
- [ ] White space balanced

### Interactions:
- [ ] All interactive elements respond to touch
- [ ] Hover states work (or hidden on mobile)
- [ ] Focus states visible
- [ ] Active states provide feedback

## Automated Testing Commands

### Quick Responsive Test:
```powershell
# Run the app
dotnet watch run --project MyPetVenues

# Then open in browser and test with DevTools
```

### Screenshot Testing (if you have tools):
```powershell
# Example with Playwright or similar
# (Add specific commands based on your testing setup)
```

## Sign-Off Checklist

Before considering mobile responsive complete:

- [ ] Tested on at least 3 different mobile widths
- [ ] Tested on at least 1 tablet width
- [ ] Tested on desktop
- [ ] Navigation works on all breakpoints
- [ ] All pages accessible and usable on mobile
- [ ] No horizontal scroll on any page
- [ ] All images load and scale properly
- [ ] Text readable at all sizes
- [ ] Touch targets adequate
- [ ] Performance acceptable on slow connections
- [ ] Tested in at least 2 different browsers
- [ ] Accessibility features working

---

**Pro Tip**: Keep DevTools open with responsive mode while developing to catch issues early!

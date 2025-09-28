# Mobile Filter Dropdown - Visual Testing Guide

## Quick Reference

### Desktop View (>768px)
```
┌─────────────────────────────────────────────────────┐
│  🔍 Search...                    ⭐ Sort By: Rating │
├─────────────────────────────────────────────────────┤
│  🎯 Filters                           Clear All     │
│                                                      │
│  Category                                            │
│  [🌳 Parks] [🍽️ Restaurants] [☕ Cafes] [🏨 Hotels] │
│  [🏪 Pet Stores] [✂️ Grooming] [🏥 Veterinary]       │
│                                                      │
│  Amenities                                           │
│  [💧 Water] [🍖 Pet Menu] [🎾 Off-Leash] [🏠 Indoor]│
│  [🌳 Outdoor] [🗑️ Waste] [🦴 Treats] [☂️ Shade]     │
└─────────────────────────────────────────────────────┘
```
**Behavior**: Chips displayed horizontally with wrapping

---

### Mobile View - Collapsed (≤768px)
```
┌──────────────────────────────┐
│ 🔍 Search...                 │
├──────────────────────────────┤
│ ⭐ Sort By: Rating           │
├──────────────────────────────┤
│                              │
│ ┌──────────────────────────┐ │
│ │ 🎯 Filters  Clear All  ▼ │ │
│ └──────────────────────────┘ │
│                              │
└──────────────────────────────┘
```
**Behavior**: Filters collapsed, only header visible

---

### Mobile View - Expanded (≤768px)
```
┌──────────────────────────────────────┐
│ 🔍 Search...                         │
├──────────────────────────────────────┤
│ ⭐ Sort By: Rating                   │
├──────────────────────────────────────┤
│                                      │
│ ┌────────────────────────────────┐   │
│ │ 🎯 Filters    Clear All      ▲ │   │
│ ├────────────────────────────────┤   │
│ │ Category                       │   │
│ │ ┌────────────────────────────┐ │   │
│ │ │ 🌳 Parks               [ ] │ │   │
│ │ │ 🍽️ Restaurants          [✓]│ │   │
│ │ │ ☕ Cafes                [ ] │ │   │
│ │ │ 🏨 Hotels               [ ] │ │   │
│ │ │ 🏪 Pet Stores           [ ] │ │   │
│ │ └────────────────────────────┘ │   │
│ ├────────────────────────────────┤   │
│ │ Amenities                      │   │
│ │ ┌────────────────────────────┐ │   │
│ │ │ 💧 Water Bowls         [✓] │ │   │
│ │ │ 🍖 Pet Menu            [ ] │ │   │
│ │ │ 🎾 Off-Leash           [✓] │ │   │
│ │ │ 🏠 Indoor              [ ] │ │   │
│ │ └────────────────────────────┘ │   │
│ └────────────────────────────────┘   │
│                                      │
└──────────────────────────────────────┘
```
**Behavior**: Full dropdown with vertical list, checkboxes visible

---

## Visual States

### 1. Filter Header - Collapsed
```
┌────────────────────────────────┐
│ 🎯 Filters    Clear All      ▼ │
└────────────────────────────────┘
```
- Background: Card background
- Shadow: Standard shadow
- Arrow: Points down (▼)
- State: Clickable

### 2. Filter Header - Expanded
```
┌────────────────────────────────┐
│ 🎯 Filters    Clear All      ▲ │
├────────────────────────────────┤
```
- Background: Secondary background
- Border radius: Top corners only
- Arrow: Points up (▲) - rotated 180°
- State: Connected to filter groups

### 3. Filter Option - Unselected
```
┌────────────────────────────────┐
│ 🌳 Parks                   [ ] │
└────────────────────────────────┘
```
- Background: Card background
- Border: Standard border
- Checkbox: Empty square

### 4. Filter Option - Selected
```
┌────────────────────────────────┐
│ 🍽️ Restaurants              [✓]│ 
└────────────────────────────────┘
```
- Background: Light pink gradient (10% opacity)
- Border: Primary pink
- Checkbox: Filled with checkmark
- Font: Semi-bold

### 5. Filter Option - Pressed (Active)
```
┌────────────────────────────────┐
│ ☕ Cafes                    [ ] │ (slightly smaller)
└────────────────────────────────┘
```
- Transform: scale(0.98)
- Visual feedback on tap

---

## Animation Sequences

### Opening Filters
```
Frame 1:  ▼ (Arrow down, filters hidden)
          ↓
Frame 2:  ▼ rotating... (0.15s)
          ↓
Frame 3:  ↔ horizontal... (0.2s)
          ↓
Frame 4:  ▲ rotated 180° (0.3s)
          Filters sliding down (max-height: 0 → 2000px)
          Opacity: 0 → 1
          ↓
Frame 5:  Fully expanded (0.4s total)
```

### Selecting a Filter
```
Frame 1:  Tap detected
          ↓
Frame 2:  Scale down (scale: 1 → 0.98)
          ↓
Frame 3:  Release
          ↓
Frame 4:  Scale back (scale: 0.98 → 1)
          Checkbox fills with gradient
          Border changes to pink
          Background gets light gradient
          ↓
Frame 5:  Filter applied
```

---

## Color Reference

### Light Theme
- **Card Background**: `#ffffff`
- **Secondary Background**: `#f8f9fa`
- **Border**: `#e5e7eb`
- **Primary Pink**: `#d946a6`
- **Pink Gradient**: `linear-gradient(135deg, #ec4899, #be185d)`
- **Text**: `#1f2937`
- **Secondary Text**: `#6b7280`

### Dark Theme
- **Card Background**: `#1f2937`
- **Secondary Background**: `#111827`
- **Border**: `#374151`
- **Primary Pink**: `#d946a6` (same)
- **Pink Gradient**: `linear-gradient(135deg, #ec4899, #be185d)` (same)
- **Text**: `#f9fafb`
- **Secondary Text**: `#d1d5db`

---

## Interaction Flow

### User Journey 1: Browse and Filter
1. User lands on `/venues` page
2. Filters are collapsed (saves space)
3. User taps "🎯 Filters" header
4. Filters slide down smoothly
5. User taps "🍽️ Restaurants"
6. Checkbox fills, border turns pink
7. Results instantly update below
8. User scrolls through filtered results
9. User taps "Clear All" to reset
10. Filters clear, all results show again

### User Journey 2: Multiple Filters
1. User taps "🎯 Filters" header
2. Filters expand
3. User selects "🌳 Parks" (checked)
4. User selects "💧 Water Bowls" (checked)
5. User selects "🎾 Off-Leash" (checked)
6. Results show only parks with water bowls AND off-leash areas
7. Count shows "3 venues found"
8. User happy with results 🎉

---

## Responsive Breakpoints

### 769px and above - Desktop
- Horizontal chip layout
- Hover effects active
- No dropdown behavior
- Multiple rows with wrap
- Immediate visibility

### 768px and below - Mobile
- Dropdown layout
- Touch-optimized
- Collapsed by default
- Vertical list
- Checkboxes on right

### 480px and below - Small Mobile
- Slightly reduced padding
- Optimized font sizes
- Same layout as mobile
- Touch targets maintained

---

## Touch Target Sizes

All interactive elements meet WCAG standards:

| Element | Width | Height | Notes |
|---------|-------|--------|-------|
| Filter Header | 100% | ~52px | Full-width tap area |
| Clear All Button | ~80px | ~32px | Embedded in header |
| Filter Option | 100% | 48px+ | Minimum touch target |
| Checkbox | 22x22px | 22x22px | Visual only, whole row is tap area |

---

## Testing Scenarios

### Scenario 1: Basic Toggle
1. Open `/venues` on mobile
2. Verify filters collapsed
3. Tap filter header
4. ✅ Filters expand smoothly
5. ✅ Arrow rotates 180°
6. Tap header again
7. ✅ Filters collapse smoothly
8. ✅ Arrow rotates back

### Scenario 2: Selection
1. Expand filters
2. Tap "Restaurants"
3. ✅ Checkbox appears
4. ✅ Border turns pink
5. ✅ Background gets light gradient
6. ✅ Results update immediately
7. ✅ Count changes

### Scenario 3: Multiple Selections
1. Expand filters
2. Select multiple categories
3. ✅ All show checkmarks
4. ✅ Results filtered correctly (AND logic)
5. Select multiple amenities
6. ✅ Further filters results
7. ✅ Count accurate

### Scenario 4: Clear Filters
1. Select several filters
2. Tap "Clear All"
3. ✅ All checkmarks disappear
4. ✅ All borders revert
5. ✅ Results show all items
6. ✅ Count updates
7. ✅ Dropdown stays open

### Scenario 5: Theme Toggle
1. View filters in light theme
2. Toggle to dark theme
3. ✅ Colors adapt correctly
4. ✅ Contrast maintained
5. ✅ Checkmarks visible
6. ✅ Animations smooth

---

## Common Issues & Solutions

### Issue: Filters don't expand
**Check**: `isFilterExpanded` state is toggling
**Solution**: Verify `ToggleFilters()` method is called

### Issue: Arrow doesn't rotate
**Check**: `.expanded` class is applied to header
**Solution**: Verify `@(isFilterExpanded ? "expanded" : "")` syntax

### Issue: "Clear All" toggles dropdown
**Check**: Event propagation
**Solution**: Ensure `@onclick:stopPropagation="true"` is present

### Issue: Checkmarks not showing
**Check**: CSS `::after` pseudo-element
**Solution**: Verify `.filter-chip.active::after` styles

### Issue: Touch targets too small
**Check**: Element heights
**Solution**: Ensure min-height: 48px on `.filter-chip`

### Issue: Animations choppy
**Check**: CSS properties being animated
**Solution**: Use `transform` and `opacity`, not `height`

---

## Device Testing Matrix

| Device | Screen Width | Expected Behavior |
|--------|-------------|-------------------|
| iPhone SE | 375px | Collapsed dropdown |
| iPhone 12/13 | 390px | Collapsed dropdown |
| iPhone 14 Pro Max | 430px | Collapsed dropdown |
| Samsung Galaxy S10 | 360px | Collapsed dropdown |
| iPad Mini | 768px | Collapsed dropdown |
| iPad Air | 820px | Horizontal chips |
| Desktop | 1440px+ | Horizontal chips |

---

## Accessibility Testing

### Keyboard Navigation
1. Tab to filter header
2. Press Enter/Space
3. ✅ Filters expand
4. Tab through filter options
5. ✅ Focus visible
6. Press Enter/Space on option
7. ✅ Filter toggles

### Screen Reader
1. Navigate to filters
2. ✅ "Filters button" announced
3. ✅ "Expanded/collapsed" state announced
4. ✅ Filter options read correctly
5. ✅ "Selected/unselected" state communicated

---

**Test completed successfully when all ✅ items pass!**

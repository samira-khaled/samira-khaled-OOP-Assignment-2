# Responsibilities.md

This document identifies the distinct responsibilities and reasons to change for the original ten classes in the SRP lab. The refactoring separates these responsibilities into cohesive types while preserving the original public behavior and meaningful Runner output.

## 1. WardBoard

### Original responsibilities
1. Managing bed assignments and patient identifiers.
2. Calculating patient acuity scores from heart rate and oxygen saturation.
3. Deciding when to trigger a pager alert and maintaining the pager log.
4. Generating nurse handoff notes and their status wording.
5. Exporting ward census data as CSV.

### Reasons to change
- Bed assignment and patient identification rules change.
- Clinical acuity scoring rules change.
- Pager alert thresholds, codes, or logging behavior change.
- Handoff note content or presentation changes.
- Census CSV structure or export requirements change.

### Refactoring direction
- `WardBoard`: Coordinates ward bed and patient data.
- `AcuityScorer`: Calculates acuity scores.
- `PagerService`: Handles pager alerts and pager log operations.
- `HandoffNoteBuilder`: Formats handoff notes.
- `CensusCsvExporter`: Exports census data as CSV.

## 2. CheckoutBasket

### Original responsibilities
1. Managing basket line items and validating quantities.
2. Calculating subtotals, discounts, and grand totals.
3. Parsing coupon text and interpreting coupon rules.
4. Applying the gift-wrapping fee.
5. Generating gift message card text.
6. Producing a simulated payment authorization code.

### Reasons to change
- Basket item handling or quantity validation changes.
- Pricing, discount, or gift-wrapping fee rules change.
- Coupon syntax and promotional rules change.
- Gift message wording or presentation changes.
- Payment authorization format or gateway integration behavior changes.

### Refactoring direction
- `CheckoutBasket`: Manages basket items and coordinates checkout calculations.
- `CouponParser`: Parses coupon text and identifies applicable coupon rules.
- `BasketPricingCalculator`: Calculates subtotal, discount, and total.
- `GiftMessageBuilder`: Generates gift message card content.
- `PaymentAuthorizationService`: Generates the simulated authorization result.

## 3. SupportTicket

### Original responsibilities
1. Maintaining ticket information and appending customer messages.
2. Inferring ticket priority from keywords in the subject and body.
3. Calculating SLA deadlines based on priority.
4. Determining whether an SLA deadline has been breached.
5. Generating public customer reply text.
6. Formatting internal escalation information.

### Reasons to change
- Ticket data management or customer-message handling changes.
- Priority classification keywords or rules change.
- SLA durations and deadline policies change.
- Public reply wording or customer communication templates change.
- Internal escalation message format changes.

### Refactoring direction
- `SupportTicket`: Maintains ticket information and coordinates ticket operations.
- `TicketPriorityClassifier`: Determines priority from ticket text.
- `SlaPolicy`: Calculates deadlines and evaluates SLA breaches.
- `PublicReplyBuilder`: Generates customer-facing replies.
- `EscalationMessageBuilder`: Formats internal escalation messages.

## 4. LoanDesk

### Original responsibilities
1. Storing loan application information.
2. Calculating a loan applicant's risk score.
3. Determining whether an applicant is eligible for a loan.
4. Generating the list of required application documents.
5. Producing loan decision letter text.
6. Exporting application and decision data as a CSV row.

### Reasons to change
- Loan application data requirements change.
- Risk scoring formulas or underwriting thresholds change.
- Loan eligibility rules change.
- Regulatory document requirements change.
- Decision letter wording or legal requirements change.
- Underwriter CSV schema or reporting requirements change.

### Refactoring direction
- `LoanDesk`: Coordinates loan application operations.
- `LoanRiskCalculator`: Calculates risk scores.
- `LoanEligibilityPolicy`: Determines eligibility.
- `RequiredDocumentsProvider`: Determines required documents.
- `LoanDecisionLetterBuilder`: Formats decision letters.
- `UnderwriterCsvExporter`: Exports application data for underwriting.

## 5. CourseEnrollmentDesk

### Original responsibilities
1. Maintaining course information, capacity, enrolled students, and the waitlist.
2. Registering students and preventing duplicate registrations.
3. Calculating waitlist positions.
4. Promoting waitlisted students when seats become available.
5. Generating welcome packet Markdown content.
6. Formatting tuition invoice lines and calculating VAT.

### Reasons to change
- Course capacity or enrollment data rules change.
- Registration, duplicate prevention, or waitlist rules change.
- Waitlist ordering or student promotion policies change.
- Welcome packet content or onboarding instructions change.
- Tuition, VAT, or invoice formatting requirements change.

### Refactoring direction
- `CourseEnrollmentDesk`: Coordinates enrollment operations and preserves the public API.
- `EnrollmentService`: Handles registration and enrollment status.
- `WaitlistService`: Calculates waitlist positions and promotes students.
- `WelcomePacketBuilder`: Generates welcome packet content.
- `TuitionInvoiceFormatter`: Calculates and formats tuition invoice lines.

## 6. KitchenTicket

### Original responsibilities
1. Managing kitchen order items and normalizing ingredient names.
2. Detecting allergens from ingredient names.
3. Estimating order preparation and ready times.
4. Applying additional preparation time when allergens are detected.
5. Rendering a thermal-printer ticket with order details and allergens.
6. Determining the expo lane hint based on allergens and estimated preparation time.

### Reasons to change
- Order item or ingredient handling changes.
- Allergen lists and detection rules change.
- Kitchen preparation-time estimates or station scheduling assumptions change.
- Allergy-related preparation procedures change.
- Thermal printer layout or formatting requirements change.
- Expo lane assignment rules change.

### Refactoring direction
- `KitchenTicket`: Maintains order items and coordinates ticket operations.
- `AllergenDetector`: Detects allergens in ingredients.
- `PreparationTimeEstimator`: Estimates readiness time.
- `ThermalTicketFormatter`: Formats the printed kitchen ticket.
- `ExpoLanePolicy`: Determines the appropriate expo lane hint.

## 7. SubscriptionBilling

### Original responsibilities
1. Storing subscription and billing-period information.
2. Calculating prorated subscription charges.
3. Generating invoice numbers and maintaining invoice sequence state.
4. Tracking failed payment attempts.
5. Generating collection or failed-payment reminder emails.
6. Formatting accounting journal entries.

### Reasons to change
- Subscription period or billing data requirements change.
- Proration calculations or financial calendar rules change.
- Invoice numbering schemes or fiscal prefixes change.
- Failed-payment tracking or collection escalation policies change.
- Collection email wording or legal notices change.
- Accounting journal entry format or integration requirements change.

### Refactoring direction
- `SubscriptionBilling`: Coordinates subscription billing operations and preserves the public API.
- `ProrationCalculator`: Calculates prorated subscription charges.
- `InvoiceNumberGenerator`: Generates invoice numbers.
- `PaymentFailureTracker`: Tracks failed payment attempts.
- `DunningEmailBuilder`: Formats collection emails.
- `LedgerJournalFormatter`: Formats accounting journal entries.

## 8. WarehousePickList

### Original responsibilities
1. Maintaining required stock-picking lines.
2. Calculating stock allocations based on required and available quantities.
3. Determining the warehouse walking order using aisle and bin locations.
4. Generating picker instructions and shortage warnings.
5. Exporting allocated items as a WMS XML batch.

### Reasons to change
- Pick-list item data or stock requirement rules change.
- Allocation and backorder policies change.
- Warehouse route ordering or layout assumptions change.
- Handheld picker instructions or shortage warning wording change.
- WMS XML schema or integration requirements change.

### Refactoring direction
- `WarehousePickList`: Maintains picking requirements and coordinates picking operations.
- `StockAllocator`: Calculates allocated quantities.
- `WarehouseRoutePlanner`: Determines the picking order.
- `PickerScriptBuilder`: Generates picking instructions and shortage warnings.
- `WmsXmlBatchBuilder`: Generates the WMS XML batch.

## 9. GradeBook

### Original responsibilities
1. Recording student scores and validating score ranges.
2. Calculating student averages.
3. Converting averages into letter grades.
4. Determining whether students meet the honor-roll criteria.
5. Generating plain-text transcripts.
6. Exporting student results as CSV.

### Reasons to change
- Score validation or score-recording rules change.
- Average calculation or rounding rules change.
- Academic grading bands change.
- Honor-roll eligibility criteria change.
- Transcript layout or content changes.
- CSV export columns, ordering, or formatting change.

### Refactoring direction
- `GradeBook`: Maintains score records and coordinates grade-related operations.
- `GradeCalculator`: Records scores and calculates averages.
- `GradePolicy`: Determines letter grades and honor-roll eligibility.
- `TranscriptFormatter`: Generates plain-text transcripts.
- `GradeCsvExporter`: Exports student results as CSV.

## 10. AppointmentDesk

### Original responsibilities
1. Managing appointment business-hour rules, including excluding Fridays and Saturdays.
2. Aligning search times with appointment slot intervals.
3. Finding the next available appointment slot.
4. Tracking booked slots and preventing duplicate bookings.
5. Generating ICS calendar content.
6. Formatting SMS appointment reminders.

### Reasons to change
- Clinic working days, opening hours, or slot-duration policies change.
- Slot alignment or appointment search behavior changes.
- Booking and duplicate-booking rules change.
- ICS format or calendar interoperability requirements change.
- SMS reminder wording or formatting changes.

### Refactoring direction
- `AppointmentDesk`: Preserves the original public API and delegates operations.
- `AppointmentScheduler`: Handles business-hour validation, slot search, and booking state.
- `IcsCalendarFormatter`: Generates ICS calendar content.
- `SmsReminderFormatter`: Formats SMS appointment reminders.

## General refactoring principles

1. Each extracted class should have one clear responsibility and a cohesive purpose.
2. Avoid vague names such as `Helper`, `Utils`, or `Manager`.
3. Do not introduce interfaces unless they are required.
4. Preserve the original public API where practical so the Runner continues to work.
5. Preserve the original business rules, side effects, and output formats unless the assignment explicitly requires a behavior change.
6. Keep the responsibilities documented here consistent with the actual classes and methods in the refactored code.

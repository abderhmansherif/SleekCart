# SleekCart 🛒
 
A production-ready e-commerce REST API built with **ASP.NET Core**, following **Clean Architecture**, **Domain-Driven Design (DDD)**, and **CQRS** patterns.
 
---
 
## What is SleekCart?
 
SleekCart is a fully-featured backend system for an e-commerce platform. It handles everything from user authentication to order management and payments — built with a focus on **clean business logic**, **data integrity**, and **maintainable code**.
 
---
 
## Key Business Features
 
### 🛍️ Product Management
- Create, update, and delete products with full validation
- Manage multiple product images (set main image, add/remove)
- Organize products by category
- Stock management with reservation system to prevent overselling
### 🛒 Shopping Cart
- Add, remove, and update item quantities
- Currency consistency enforced — all items in a cart must use the same currency
- Cart is automatically cleared after successful payment
### 📦 Order Management
- Clean checkout flow: Cart → Order → Payment
- Full order status lifecycle: `Pending → Confirmed → Shipped → Delivered` (with cancellation support)
- Order status history tracked with timestamps and notes
- Duplicate order item prevention
### 💳 Payments
- Supports multiple payment providers
- Payment retry support (one order can have multiple payment attempts)
- Clear payment status tracking: `Pending → Succeeded / Failed / Refunded`
### 🎟️ Coupons
- Single-use and multi-use coupon types
- Usage limit enforcement
- Discount applied at order level
### 🔔 Notifications
- Event-driven notifications triggered by domain events (order placed, payment succeeded, etc.)
### 👤 User Management
- Register, login, and refresh tokens (JWT + Refresh Token)
- Profile management
- Multiple shipping addresses per user
- Role-based access (Admin / Customer)
---
 
## Why This Architecture?
 
### Clean Architecture
The codebase is split into four layers:
- **Domain** — Core business rules, entities, value objects, domain events
- **Application** — Use cases via CQRS commands and queries
- **Infrastructure** — Database, storage, external services
- **API** — HTTP layer, controllers, middleware
This means business logic is completely independent of frameworks or databases.
 
### Domain-Driven Design (DDD)
- Every business concept has its own **Value Object** with validation (e.g., `Money`, `Email`, `StockQuantity`)
- **Aggregate Roots** protect business invariants
- **Domain Events** decouple side effects (e.g., `PaymentSucceededEvent` triggers cart clearing and notifications)
- **Factories** handle complex object creation
### CQRS with MediatR
- Commands (write operations) and Queries (read operations) are fully separated
- Each use case lives in its own folder with its Handler, Validator, and Command/Query
---
 
## Business Rules Enforced
 
| Rule | How |
|------|-----|
| No overselling | Stock reservation system before order confirmation |
| Currency consistency | Cart rejects items with mismatched currency |
| No duplicate products | Idempotency checks on product creation |
| Valid order transitions | State machine prevents invalid status changes |
| Coupon usage limits | Enforced at domain level, not just API level |
| Payment retries | Modeled explicitly — one order, many payment attempts |
 
---
 
## Tech Stack
 
| Technology | Purpose |
|------------|---------|
| ASP.NET Core | Web API framework |
| Entity Framework Core | ORM + Code-First migrations |
| SQL Server | Database |
| MediatR | CQRS pipeline |
| FluentValidation | Input validation |
| JWT + Refresh Tokens | Authentication |
| Cloudinary / Storage | Image management |
 
---

## Getting Started
 
```bash
# Clone the repo
git clone https://github.com/abderhmansherif/SleekCart.git
 
# Update connection string in appsettings.json
 
# Apply migrations
dotnet ef database update
 
# Run the API
dotnet run --project SleekCart.API
```
 
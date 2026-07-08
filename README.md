# E-Commerce Microservices - .NET 8 + React

A GitHub-ready portfolio project for **.NET Full Stack Developer** roles. It demonstrates Clean Architecture, JWT authentication, API Gateway, RabbitMQ event-driven communication, Redis caching, Docker, SQL Server, React TypeScript, and unit testing.

## Architecture

```txt
React Client
   |
API Gateway
   |
-------------------------------------------------
| Identity | Product | Cart | Order | Payment |
-------------------------------------------------
       RabbitMQ Events + Redis Cache + SQL Server
```

## Tech Stack

- Backend: .NET 8 Web API
- Frontend: React + TypeScript + Vite
- Database: SQL Server
- Cache: Redis
- Messaging: RabbitMQ
- Auth: JWT + Refresh Token pattern
- Testing: xUnit
- DevOps: Docker Compose + GitHub Actions

## Services

| Service | Responsibility |
|---|---|
| IdentityService | Login, Register, JWT token |
| ProductService | Products, categories, pagination, search |
| CartService | Shopping cart and Redis cache |
| OrderService | Checkout and order history |
| PaymentService | Mock payment processing |
| ApiGateway | Single entry point for frontend |

## Run with Docker

```bash
docker compose up --build
```

Frontend: http://localhost:5173  
API Gateway: http://localhost:5000/swagger

## Default Login

```txt
Email: admin@shop.com
Password: Admin@123
```

## Important Features to Explain in Interview

- Clean Architecture separation: API, Application, Domain, Infrastructure
- JWT authentication and refresh token flow
- Product pagination/filtering/search
- Redis cache for cart/product reads
- RabbitMQ event published after order creation
- Global exception handling middleware
- Repository pattern and EF Core
- Dockerized local environment
- GitHub Actions CI pipeline

## Folder Structure

```txt
backend/
  ApiGateway/
  Services/
    IdentityService/
    ProductService/
    CartService/
    OrderService/
    PaymentService/
  Shared/
frontend/
  src/
tests/
database/
.github/workflows/
```

## Interview Talking Point

> I built this project using microservices and Clean Architecture. Product, Order, Cart, Identity, and Payment are separated services. API Gateway handles routing, JWT is used for authentication, Redis improves performance, and RabbitMQ is used for asynchronous order events. Docker Compose helps run the full system locally.

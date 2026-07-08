# How to Explain This Project in Interview

I created an e-commerce microservices system using .NET 8 and React. The backend is split into services like Identity, Product, Cart, Order, and Payment. The frontend communicates through an API Gateway, so the client does not directly call every service.

For authentication, I used JWT tokens. Product APIs support pagination, filtering, and search. Cart data can be cached using Redis. Order creation can publish an event to RabbitMQ, so payment and notification flows can run asynchronously.

I followed Clean Architecture ideas by keeping business logic separate from API endpoints and infrastructure concerns. I also added Docker Compose so the whole system can run locally with SQL Server, Redis, RabbitMQ, backend services, and React UI.

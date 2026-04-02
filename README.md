#  BACKEND CHALLENGE
Technologies Used: C#, ASP.NET Core, Microsoft SQL Server, Docker, Web API, FluentValidation, Ocelot API Gateway, RabbitMQ

##  Proje Genel Şeması

- ApiGateway
  * TesodevBackendC.OcelotGateway Project
- Services
  * Customer
    - TesodevBackendC.Customer.WebApi Project
  * Order
    - Core
       - TesodevBackendC.Order.Application Project
       - TesodevBackendC.Order.Domain Project
    - Infrastructure
       - TesodevBackendC.Order.Persistence Project
    - Presentation
       - TesodevBackendC.Order.WebApi Project
       - 
The Order Management System consists of two microservices, Customer and Order, which manage customer and order operations. Ocelot was used as the API Gateway.

Customer Microservice: The Customer microservice was implemented as a single project using N-Tier architecture.
- Entities Layer: Created Address and Customer entities, establishing a one-to-many relationship between Customer and Address.
- DataAccess Layer: Interfaces were created for each entity in the Abstract folder, and basic CRUD operations were implemented using Entity Framework. The CustomerDbContext was written in the Concrete folder, and migrations were performed on MS SQL Server using a Docker container.
- Business Layer: Implemented basic CRUD operations and custom methods, e.g., retrieving Customer and Address information by Customer ID, fetching all customers with their addresses. FluentValidation was used for validations.
- API Layer: CRUD operations were exposed as API endpoints, and all methods were tested.

Order Microservice: The Order microservice was built using Onion Architecture.
- Domain Layer: Established a many-to-many relationship between OrderDetail and Product with a junction table. The OrderLog class was created to store RabbitMQ messages in the database.
- Application Layer: Repository interfaces were defined and implemented by repository classes within the Persistence layer. CRUD operations, product listing by OrderDetail ID, and order cancellation or activation processes were developed using the CQRS design pattern. Data validation was also handled within this layer.
- Persistence Layer: The database environment was established using MSSQL running within a Docker container.
- Web API Layer: "Create OrderDetail" operations were executed using RabbitMQ messaging, and an OrderConsumer was utilized to persist these messages to the database. Standard CRUD operations were exposed as API endpoints.

Testing & Verification: All CRUD operations, custom methods, and FluentValidation logic were thoroughly tested and verified via Postman to ensure full system functionality and reliability.

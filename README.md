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
- Application Katmanı: Repository interface yazılarak Persistence katmanındaki repository sınıfına implement edildi. CRUD işlemleri, OrderDetail ID'ye göre ürün listesi, sipariş iptali veya aktifleştirme işlemleri CQRS design pattern kullanılarak yazıldı. Validasyonlar bu katmanda gerçekleştirildi.
- Persistence Katmanı: Docker'da container oluşturularak MSSQL ile veritabanı kuruldu.
- Web API Katmanı: RabbitMQ mesajları kullanılarak Create OrderDetail işlemleri gerçekleştirildi ve OrderConsumer ile veritabanına mesajlar kaydedildi. CRUD işlemleri API endpointleri olarak yazıldı.

Postman ile tüm metotlar için CRUD işlemleri, özel metotlar ve FluentValidation testleri gerçekleştirildi ve çalışmaları doğrulandı.

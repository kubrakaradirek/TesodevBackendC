#  TESODEV BACKEND CHALLENGE
Kullanılan Teknolojiler: C#, ASP.NET Core, Microsoft SQL Server, Docker, Web API, FluentValidation, Ocelot API Gateway, RabbitMQ

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
Sipariş yönetim sistemi, müşteri ve sipariş işlemlerini yönetmek için iki mikroservisten oluşmaktadır: Customer ve Order mikroservisleri. API Gateway için Ocelot kullanıldı.

Customer Mikroservisi : Customer mikroservisi tek bir projede gerçekleştirildi ve N-Tier mimari kullanılarak yapılandırıldı.
- Entities Katmanı: Adress ve Customer entityleri oluşturularak, Customer ile Adress arasında bire-çok ilişki kuruldu.
- DataAccess Katmanı: Abstract klasöründe her bir entity için interfaceler oluşturuldu ve EF kullanılarak temel CRUD işlemleri yapıldı. Concrete klasöründe CustomerDbContext yazıldı ve Docker üzerinde container oluşturularak MS SQL Server ile migration yapıldı.
- Business Katmanı: Temel CRUD işlemleri ve özel metotlar yazıldı. Örneğin, Customer ID'ye göre Customer ve Adress bilgilerini getirme, tüm customer listesini adres bilgileriyle birlikte getirme gibi işlemler yapıldı. FluentValidation kullanılarak validasyonlar sağlandı.
- API Katmanı: CRUD işlemleri API endpointleri olarak yazıldı ve tüm metotlar test edildi.

Order Mikroservisi : Order mikroservisinde Onion Architecture kullanıldı.
- Domain Katmanı: OrderDetail ve Product arasında many-to-many ilişki kurularak bir ara tablo eklendi. OrderLog sınıfı, RabbitMQ mesajlarının veritabanında tutulması için oluşturuldu.
- Application Katmanı: Repository interface yazılarak Persistence katmanındaki repository sınıfına implement edildi. CRUD işlemleri, OrderDetail ID'ye göre ürün listesi, sipariş iptali veya aktifleştirme işlemleri CQRS design pattern kullanılarak yazıldı. Validasyonlar bu katmanda gerçekleştirildi.
- Persistence Katmanı: Docker'da container oluşturularak MSSQL ile veritabanı kuruldu.
- Web API Katmanı: RabbitMQ mesajları kullanılarak Create OrderDetail işlemleri gerçekleştirildi ve OrderConsumer ile veritabanına mesajlar kaydedildi. CRUD işlemleri API endpointleri olarak yazıldı.

Postman ile tüm metotlar için CRUD işlemleri, özel metotlar ve FluentValidation testleri gerçekleştirildi ve çalışmaları doğrulandı.

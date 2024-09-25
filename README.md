# 🌐 Modern Web API Uygulaması

Bu proje, **modern yazılım mimarisi** prensiplerini temel alan bir **Web API** uygulamasıdır. **Onion Architecture** kullanılarak geliştirilmiş olup katmanlar arasında net bir ayrım sağlanmış ve uygulamanın sürdürülebilirliği artırılmıştır.

## 🚀 Özellikler

### 🧑‍💻 Mimariler ve Desenler

- **Onion Architecture**: Katmanlı yapı, daha sürdürülebilir ve test edilebilir bir mimari sağlar.
- **CQRS (Command Query Responsibility Segregation)**: Veri güncellemeleri ve sorgulamalarını ayrı ayrı yöneterek performansı artırır.
- **Repository ve Unit of Work Desenleri**: Veri erişiminde kod tekrarını önler, test edilebilirliği artırır.
- **MediatR**: Uygulama içi iletişim ve veri akışı yönetimini kolaylaştırır.
- **AutoMapper**: DTO (Data Transfer Object) ve entity nesneleri arasında otomatik dönüşüm sağlar.

### 🛠️ Teknolojiler ve Kütüphaneler

- **Entity Framework Core**: Güçlü veri erişim katmanı, migration özellikleri ile veritabanı yönetimi.
- **Fluent Validation**: Gelen verilerin doğruluğunu sağlayarak uygulamanın güvenilirliğini artırır.
- **Global Exception Handler**: Uygulama genelinde hata yönetimi yaparak kullanıcı deneyimini geliştirir.

### 🔐 Güvenlik

- **Authentication ve Authorization**: JWT (JSON Web Token) ile token tabanlı kimlik doğrulama sistemi.
- **Refresh Token**: Kullanıcı oturumlarını yönetmek için refresh ve access token mekanizmaları entegre edilmiştir.
- **Identity Yapısı**: Kullanıcı yönetimi için kolaylık sağlar.

### 🛠️ CRUD İşlemleri

Kullanıcı dostu bir arayüz ile **Create**, **Read**, **Update** ve **Delete** işlemleri hızlı ve etkili bir şekilde gerçekleştirilir.

## 📊 Uygulamanın Avantajları

- **Sürdürülebilirlik**: Onion Architecture ve katmanlı yapı ile uzun vadede sürdürülebilirlik.
- **Performans**: CQRS ile veri yönetimi ve performans artışı.
- **Test Edilebilirlik**: Repository ve Unit of Work desenleri ile test edilebilirlik artırılmıştır.
- **Güvenlik**: JWT ve token mekanizmaları ile güçlü bir kimlik doğrulama sağlanmıştır.

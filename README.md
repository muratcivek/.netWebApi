Bu proje, modern yazılım mimarisi prensiplerini temel alan bir Web API uygulamasıdır. 
**Onion Architecture** kullanılarak geliştirilmiştir, böylece katmanlar arasında net bir ayrım sağlanmış ve uygulamanın sürdürülebilirliği artırılmıştır. 
Proje, hem geliştirme (dev) hem de üretim (prod) ortamları için ayrı ayar dosyaları ile yapılandırılmıştır.

**Entity Framework Core** ile güçlü bir veri erişim katmanı oluşturulmuş; **migration** özellikleri sayesinde veritabanı şemasının kolayca yönetilmesi sağlanmıştır.

**Repository ve Unit of Work** desenleri kullanılarak, veri erişim katmanında kod tekrarının önüne geçilmiş ve test edilebilirlik artırılmıştır.

**CQRS (Command Query Responsibility Segregation)** mimarisi ile uygulama, veri güncellemeleri ve sorgulamalarını ayrı olarak yönetir, bu sayede performans ve ölçeklenebilirlik sağlanmıştır.

**MediatR** kütüphanesi ile uygulama içindeki iletişim ve veri akışı yönetimi kolaylaştırılmıştır.

**AutoMapper** ile **DTO (Data Transfer Object)** ile entity nesneleri arasında otomatik dönüşüm sağlanarak kod basitliği artırılmıştır.

**CRUD işlemleri**, kullanıcı dostu bir arayüz ile hızlı ve etkili bir şekilde gerçekleştirilmiştir.

**Global Exception Handler** ile uygulama genelinde hata yönetimi yapılmış, kullanıcı deneyimi geliştirilmiştir.

**Fluent Validation** ile gelen verilerin doğruluğu sağlanarak, uygulamanın güvenilirliği artırılmıştır.

**Authentication ve Authorization** mekanizmaları kullanılarak, kullanıcı güvenliği üst seviyeye çıkarılmıştır. **JWT (JSON Web Token)** ile token tabanlı kimlik doğrulama sistemi geliştirilmiştir.

Kullanıcıların oturumlarını yönetmek için **refresh token** ve **access token** uygulamaları entegre edilmiştir.

**Identity** yapısı kullanılarak kullanıcı yönetimi kolaylaştırılmıştır.

Bu proje, modern yazılım geliştirme prensiplerini etkili bir şekilde uygulayarak, sağlam, güvenilir ve ölçeklenebilir bir Web API sunmaktadır. Bu sayede, hem akademik hem de profesyonel kariyerimde önemli bir katkı sağlamaktadır.

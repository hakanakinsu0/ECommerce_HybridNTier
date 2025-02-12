# Hybrid N-Tier Mimari E-Ticaret Projesi

## 📌 Proje Hakkında

Bu proje, .NET Core kullanılarak geliştirilmiş, **Hybrid N-Tier** mimarisine sahip bir e-ticaret uygulamasıdır. Proje, geleneksel **N-Tier mimariyi** modern geliştirme pratikleriyle birleştirerek esneklik ve performans odaklı bir yapı sunar.  

Projenin amacı, sürdürülebilir bir yapı oluşturarak, ileri seviye mimari prensiplere uygun bir e-ticaret platformu geliştirmektir.

---

## 🔧 Kullanılan Teknolojiler

- **.NET Core 6.0**
- **Entity Framework Core**
- **AutoMapper**
- **Bogus** (Test verisi üretimi)
- **Dependency Injection**
- **Fluent Validation**
- **Identity Framework**
- **Microsoft SQL Server**
- **SMTP (Mail Gönderimi)**

---

## 📂 Proje Yapısı

Proje 7 farklı katmandan oluşmaktadır:

1. **Project.Entities**  
   - Domain entitilerini içerir.  
   - `BaseEntity`, `AppUser`, `Category`, `Product`, `Order`, `OrderDetail` gibi sınıfları barındırır.

2. **Project.Conf**  
   - Veri tabanı ilişkileri ve yapılandırmalarını içerir.  
   - `BaseConfiguration` sınıfı ile diğer tüm entitilerin ayarları yapılır.

3. **Project.Dal**  
   - Veri erişim katmanıdır.  
   - `MyContext` sınıfı, repository yapıları (abstract ve concrete), `Bogus` ile fake veri üretimi burada yer alır.

4. **Project.Bll**  
   - İş mantığı (Business Logic) katmanıdır.  
   - DTO (Data Transfer Objects) ve manager yapıları burada bulunur.  

5. **Project.Common**  
   - Ortak kullanılabilecek araçları içerir.  
   - Örneğin, `MailService` ile SMTP protokolü üzerinden e-posta gönderimi yapılır.

6. **Project.MvcUI**  
   - Web kullanıcı arayüzü katmanıdır.  
   - `appsettings.json` üzerinden bağlantı stringi yapılandırılmıştır.

7. **Project.WebApi**  
   - API entegrasyonu için oluşturulan katmandır.  

---

## 🚀 Projenin Öne Çıkan Özellikleri

1. **Hybrid Mimari**  
   - N-Tier mimarisi temel alınarak esnek, interfacelerle desteklenmiş ve modern geliştirme pratikleri entegre edilmiştir.  

2. **Identity Framework Kullanımı**  
   - Kullanıcı yönetimi ve roller için `IdentityUser` sınıfından yararlanılmıştır.  

3. **Bogus ile Test Verisi**  
   - `Category`, `Product`, `AppUser` gibi entitilere kolayca fake veri üretilmiştir.  

4. **Dependency Injection ile Çözümleme**  
   - Middleware’e bağımlılıkları eklemek için custom resolverlar (`DbContextResolver`, `RepositoryResolver`, `ManagerResolver`) tanımlanmıştır.  

5. **AutoMapper ile Mapleme**  
   - DTO ve domain entity'ler arasında hızlı ve kolay mapleme yapılmıştır.  

6. **Mail Gönderim Servisi**  
   - `MailService` kullanılarak SMTP protokolü üzerinden e-posta gönderimi gerçekleştirilmiştir.  

---

## 🔑 Kurulum

1. **Gerekli Kütüphaneleri Yükleyin**  
   Proje için aşağıdaki NuGet paketlerini yükleyin:  
   - `Microsoft.EntityFrameworkCore.SqlServer`  
   - `Microsoft.EntityFrameworkCore.Tools`  
   - `Microsoft.EntityFrameworkCore.Proxies`  
   - `AutoMapper`  
   - `Bogus`  
   - `FluentValidation.AspNetCore`

2. **Veritabanını Ayarlayın**  
   - `appsettings.json` dosyasına bağlantı stringini ekleyin.  
   - Veritabanını oluşturmak için aşağıdaki komutları çalıştırın:  
     ```bash
     Add-Migration InitialMigration
     Update-Database
     ```

3. **Middleware Ayarları**  
   - `Program.cs` dosyasına aşağıdaki satırları ekleyin:  
     ```csharp
     builder.Services.AddDbContextService();
     builder.Services.AddIdentityService();
     builder.Services.AddRepositoryService();
     builder.Services.AddManagerService();
     builder.Services.AddMapperService();
     ```

4. **Mail Gönderim Ayarları**  
   - `MailService.cs` dosyasındaki `sender` ve `password` bilgilerini kendi e-posta adresinize göre düzenleyin.  

5. **Proje Çalıştırma**  
   - `Project.MvcUI` katmanını `Set as Startup Project` olarak ayarlayın ve projeyi çalıştırın.  

---

## 📚 Mimari Detaylar

1. **Katmansal Bağımlılık**  
   - Katmanlar arası bağımlılık mümkün olduğunca minimal düzeyde tutulmuştur.  
   - DAL katmanı sadece BLL katmanına bağlıdır; BLL ise sadece UI ile iletişim kurar.  

2. **Validation ve Business Logic**  
   - Tüm validasyon işlemleri `Fluent Validation` ile yapılmıştır.  
   - CRUD işlemleri öncesinde iş mantıkları kontrol edilmiştir.  

3. **Repository ve Manager Pattern**  
   - Repository’ler sadece CRUD işlemlerini içerirken, tüm iş mantığı Manager sınıflarında uygulanmıştır.  

---



## 📬 İletişim

Eğer bu proje hakkında sorularınız veya önerileriniz varsa, lütfen bana LinkedIn üzerinden ulaşın ya da GitHub üzerinden bir issue açın. 😊

---

## ⭐ Destek Ol

Projeyi faydalı bulduysanız GitHub’da ⭐ vermeyi unutmayın!  

Teşekkürler ve keyifli kodlamalar! 🎉

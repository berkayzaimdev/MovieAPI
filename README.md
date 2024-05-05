# Movie API

## Genel Bakış
Movie API, küresel çapta film veritabanlarına erişim sağlayan RESTful bir web servisidir. API, film verilerini sorgulamak, güncellemek ve yönetmek için güçlü bir arayüz sunar. Filmler hakkında geniş bilgi yelpazesine, türlerine, oyuncularına ve çok daha fazlasına kolayca erişebilirsiniz.

## Başlarken

Bu bölüm, Movie API'yi yerel geliştirme ortamınızda nasıl kuracağınızı ve çalıştıracağınızı açıklar.

### Önkoşullar

Movie API'nin çalıştırılabilmesi için aşağıdaki araçların yüklü olması gerekmektedir:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) veya tercih ettiğiniz bir veritabanı

### Kurulum

1. Projeyi GitHub'dan klonlayın:
`` git clone https://github.com/berkayzaimdev/movieapi.git ``

2. Klonlanan dizine gidin:
`` cd movieapi ``

3. Bağımlılıkları yükleyin:
`` dotnet restore ``

4. Veritabanını yapılandırın:
`` dotnet ef database update ``

5. Uygulamayı yerel olarak çalıştırın:
`` dotnet run ``

## Özellikler

Movie API aşağıdaki özellikleri sunar:
- **Film Listeleme:** Tüm filmleri listeleme imkanı.
- **Film Detayları:** Belirli bir film hakkında detaylı bilgi edinme.
- **Film Ekleme:** Yeni film kayıtları ekleyebilme.
- **Film Güncelleme:** Mevcut film kayıtlarını güncelleme.
- **Film Silme:** Filmleri veritabanından kaldırma.
- **Oyuncu Bilgileri:** Oyuncular hakkında bilgi sağlama ve onların filmlerle ilişkilerini gösterme.
- **Tür Bilgileri:** Farklı film türlerini ve bu türler altındaki filmleri listeleme.

## Katkıda Bulunma

Movie API'ye katkıda bulunmak istiyorsanız, lütfen aşağıdaki adımları takip edin:
1. Repo'yu forklayın.
2. Özellik eklemek veya hata düzeltmek için yeni bir dal oluşturun (`git checkout -b feature/your_feature`).
3. Değişikliklerinizi commit edin (`git commit -am 'Add some feature'`).
4. Dalınızı itin (`git push origin feature/your_feature`).
5. Yeni bir Pull Request oluşturun.

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.

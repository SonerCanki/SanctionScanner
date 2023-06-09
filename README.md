# SanctionScanner

Gereksinimler
.NET 6 SDK
Visual Studio 2022 gibi bir IDE
MSSQL veritabanı sunucusu

Kurulum
Bu depoyu klonlayın: git clone https://github.com/SonerCanki/SanctionScanner.git
Visual studio'da solutiona sağ tık yaparak Configure startup projects kısmından api ve ui projelerini start olarak seçip apply dedikden sonra projeyi çalıştırabilirsiniz.


Yapılandırma
Uygulama, yapılandırma için appsettings.json dosyasını kullanır. Bu dosya içinde aşağıdaki ayarları yapabilirsiniz:

Database:ConnectionString: MSSQL veritabanı bağlantı dizesi.

Kullanım
Proje bir kütüphane uygulamasıdır proje başladığında bir listeleme ekranı bulunmaktadır.
Tablonun sol üst köşesindeki kitap ekle butonu ile kitapekleyebilirsiniz kitap ekledikten sonra ödünç ver butonu ile kitabı birine teslim edebilirsiniz.
Kitabı ödünç verdikten sonra buton teslim al butonu olarak gözükür ve kitabı tekrardan teslim alabilirsiniz.

Katmanlı Mimarisi
Uygulama, aşağıdaki katmanlı mimari yapısını kullanır:

SanctionScanner.Common: Bu katman, Dto, enum extension methodlarımı içerir.
SanctionScanner.Core: Bu katman, bütün base yapıları içerir (CoreEntity,IRepository).
SanctionScanner.Model: DataContext ve entitylerin bulunduğu katman.
SanctionScanner.Service: Bu katman, uygulamanın iş mantığını içerir. veritabanı işlemleri ve diğer işlemler bu katmanda gerçekleştirilir. İş mantığı, uygulama için temel kuralları ve süreçleri uygular.
SanctionScanner.API: Bu katmanda, gelen isteklerin işlenmesi, doğrulanması ve sonuçların dönülmesi sağlanalır
SanctionScanner.UI:Bu katman, kullanıcı arayüzünü içerir. 
Bu katmanlar, uygulamanın daha iyi ölçeklenebilir, bakımı kolay ve test edilebilir olmasını sağlar.

# 🗂️ Hafta02 — UML Nedir? Neden Sınıf Diyagramı? (Teori + Görsel)

Bu hafta, UML’nin (Unified Modeling Language) amacını, kapsamını ve özellikle sınıf diyagramının neden güçlü bir iletişim aracı olduğunu ele alıyoruz. Kod ayrıntılarına girmeden; notasyon, ilişki türleri, çokluk (multiplicity) ve yönlülük (navigability) gibi temel kavramları sistematik biçimde işliyoruz.

## 🎯 Öğrenme Hedefleri
- UML’nin yazılım geliştirme sürecindeki rolünü ve faydalarını açıklayabilmek.
- Sınıf diyagramının bileşenlerini (sınıf, nitelik, operasyon) doğru notasyonla ifade edebilmek.
- İlişkileri (association, aggregation, composition, generalization, realization) doğru seçip görselleştirebilmek.

## ❓ UML Nedir?
- UML, yazılım sistemlerini standart ve görsel bir dille modellemek için kullanılan bir notasyon setidir.
- Hem yapısal diyagramları (Class, Object, Package, Component) hem davranışsal diyagramları (Sequence, Activity, State, Use Case) kapsar.
- Amaç, ekip üyeleri arasında ortak bir dil oluşturarak analiz–tasarım–dokümantasyon süreçlerini hızlandırmaktır.

## 🎯 Neden UML Sınıf Diyagramı?
- 🧭 Alan modelinizi netleştirir: Sınıflar, nitelikler ve işlemler tek bir resimde görünür.
- 🔗 İlişkileri görünür kılar: İki sınıf arasındaki bağın türü ve çokluğu (1, 0..1, *, 1..*) belirtilir.
- 🤝 Ortak dil: Geliştirici, analist, test mühendisi ve paydaşların aynı görsele bakıp aynı şeyleri anlamasını sağlar.
- 🧪 Hata yakalama: Yanlış tasarım kararları, kod yazılmadan önce diyagramda fark edilebilir.
- 🧱 İzlenebilirlik: Gereksinim → analiz modeli → tasarım modeli → kod ilişkileri daha şeffaf olur.

## 🧭 Temel Notasyon ve İlişkiler
- Görünürlük: `+ public`, `- private`, `# protected`
- İlişki türleri:
  - 🔗 Association: Sınıflar arası genel ilişki (ör. “Öğrenci ders alır”).
  - ◇ Aggregation (zayıf sahiplik): Bütün–parça ilişkisi; parça bağımsız yaşayabilir (ör. “Ekip — Üye”).
  - ◆ Composition (güçlü sahiplik): Parça bütünün yaşam döngüsüne bağlıdır (ör. “Kitap — Sayfa”).
  - 🔺 Generalization (kalıtım): Üst–alt sınıf hiyerarşisi (is-a ilişkisi).
  - 🔻 Realization (arayüz gerçekleştirme): Bir arayüzün somut sınıflarca uygulanması.
- Navigability (yönlülük): İlişkinin hangi yönde erişim/bağımlılık içerdiğini belirtir; diyagram okunabilirliğini artırır.
- Multiplicity (çokluk): 1, 0..1, *, 1..* gibi notasyonlarla tarafların kaç örnek üzerinden ilişki kurduğunu gösterir.
![iliskiler](../iliskiler.png)
## 📐 Örnek A — Kütüphane Modeli
Bu model, “Yazar” ve “Yayınevi”nin çok sayıda “Kitap” ile ilişkisini ortaya koyar.
```mermaid
classDiagram
    class Kitap {
      +ad: string
      +isbn: string
    }
    class Yazar {
      +ad: string
    }
    class Yayinevi {
      +ad: string
    }

    Yazar "1" -- "*" Kitap : yazar
    Yayinevi "1" -- "*" Kitap : yayinlar
```
- Not: Burada association kullanılmıştır; bir kitap yalnızca bir yayıneviyle ilişkilendirilebilir varsayımı sistem kurallarınıza göre değişebilir.

## 📐 Örnek B — Kitap ve Sayfa (Composition)
Bir sayfa, bu örnekte yalnızca ait olduğu kitabın parçası olarak var olur; bu nedenle composition uygundur.
```mermaid
classDiagram
    class Kitap {
      +baslik: string
    }
    class Sayfa {
      +sayfaNumarasi: int
    }

    Kitap *-- "*" Sayfa : composition
```
- Gerekçe: Kitap kaldırıldığında sayfalar da o kitabın parçası olma özelliğini yitirir.

## 📐 Örnek C — Ev ve Oda (Composition)
Bu örnekte odalar, evin parçalarıdır ve tek başlarına ayrı bir evin odası olarak var olamazlar; bu nedenle composition kullanılır.
```mermaid
classDiagram
    class Ev {
      +adres: string
    }
    class Oda {
      +odaNumarasi: int
    }

    Ev "1" *-- "1..*" Oda : icerir
```
- Gerekçe: Ev ortadan kalktığında, ona ait odalar da bu modelde varlığını yitirir.

## 📐 Aggregation Örnekleri
Aggregation’da bütün ile parçaları arasında zayıf sahiplik vardır; bütün silinse bile parçalar var olmaya devam edebilir. Mermaid diyagramlarında boş baklava `o` aggregation ilişkisini gösterir.

### Örnek 1 — Takım ve Oyuncu
Bir takım oyunculardan oluşur; takım dağılsa bile oyuncular var olmaya devam eder.
```mermaid
classDiagram
    class Takim {
      +ad: string
    }
    class Oyuncu {
      +ad: string
    }

    Takim "1" o-- "*" Oyuncu : oyunculari
```

### Örnek 2 — Çalma Listesi ve Şarkı
Bir çalma listesi şarkıları içerir; liste silinse bile şarkılar kütüphanede kalır ve başka listelerde kullanılabilir.
```mermaid
classDiagram
    class CalmaListesi {
      +ad: string
    }
    class Sarki {
      +baslik: string
    }

    CalmaListesi "*" o-- "*" Sarki : sarkilari
```

## 🧯 Aggregation vs Composition — Seçim Ölçütleri
- Parça bağımsız var olabilir mi? Evetse aggregation, hayırsa composition.
- Yaşam döngüsü kime bağlı? Parça, bütün olmadan anlamsızsa composition.
- Sahiplik derecesi nedir? Zayıf sahiplik aggregation, güçlü sahiplik composition.

## 📝 Alıştırmalar
1) “Restoran–Masa–Sipariş” için sınıf diyagramı çizin; hangi ilişkinin aggregation, hangisinin composition olduğuna gerekçe yazın.
2) “Kullanıcı–Rol–Yetki” modelini bir “KullaniciRol” köprü sınıfıyla genişletin ve diyagramlayın.
3) Bir projede navigability’nin (ok yönü) okunabilirliğe katkısını örnekle açıklayın.

## 📚 Önerilen Okuma
- UML ilişkileri: https://www.uml-diagrams.org/class-diagrams-relationships.html
- Sınıf diyagramı notasyonu: https://www.uml-diagrams.org/class-diagrams-overview.html

---

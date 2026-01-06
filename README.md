# 🍔 Ready Sipariş - QR Kodlu & Real-Time Restoran Sipariş Sistemi

**Ready Sipariş**, restoranlardaki sipariş süreçlerini dijitalleştiren, masalar ile yönetim paneli arasında **SignalR** teknolojisi ile gerçek zamanlı (Real-Time) iletişim kuran, **N-Katmanlı Mimari (N-Tier Architecture)** yapısına sahip bir otomasyon projesidir.

<img width="1913" height="916" alt="image" src="https://github.com/user-attachments/assets/41f9bac8-9c5d-4446-981e-9d97d0fd34f2" />


## 🚀 Projenin Amacı
Bu proje, klasik restoran sipariş süreçlerini modernize ederek; müşterinin QR kod ile menüye ulaşmasını, sipariş vermesini ve bu siparişin anlık olarak yönetim paneline (mutfak/kasa) düşmesini sağlar. Sayfa yenilemeye gerek kalmadan (AJAX & SignalR) veri akışı hedeflenmiştir.

## 🔑 Öne Çıkan Özellikler

### 1. ⚡ SignalR ile Gerçek Zamanlı İletişim
* **Canlı Masa Takibi:** Müşteri siparişi onayladığı anda, Admin panelindeki masa durumu anlık olarak **"Boş"tan "Dolu"ya** geçer (WebSocket).
* **Anlık İstatistikler:** Toplam kasa tutarı, aktif sipariş sayısı ve kategori bazlı ürün sayıları anlık olarak Admin paneline yansır.

### 2. 📱 Dahili QR Kod Modülü
* Dış servislere bağımlı olmadan, backend tarafında **QR Kod Üretme (Generate)** ve **QR Kod Çözümleme (Decode)** işlemleri yapılabilir.
* Her masaya özel üretilen QR kodlar, ilgili masanın ID bilgisini taşır.

### 3. 🛒 Sepet ve Sipariş Yönetimi
* Dinamik sepet işlemleri (Ürün Ekle/Sil, Adet Güncelle).

### 4. 🔐 Güvenlik ve Mimari
* **N-Katmanlı Mimari (N-Tier):** Entity, DataAccess, Business ve Presentation (UI) katmanları ile sürdürülebilir yapı.
* **ASP.NET Core Identity:** Kullanıcı kayıt, giriş işlemleri.

## 🛠 Kullanılan Teknolojiler

* **Backend:** ASP.NET Core 8.0 Web API
* **Mimari:** N-Tier Architecture (N-Katmanlı Mimari)
* **Real-Time:** SignalR
* **Veritabanı:** MS SQL Server & Entity Framework Core (Code First)
* **Frontend:** HTML5, CSS3, Bootstrap, JavaScript (AJAX, jQuery)
* **Araçlar:** Swagger UI, Postman

## 📷 Ekran Görüntüleri

### 🖥️ Admin Paneli - Anlık Masa Takibi (SignalR)
> *Sipariş geldiğinde masalar anlık olarak renk değiştirir.*
<img width="1590" height="844" alt="image" src="https://github.com/user-attachments/assets/556a4f87-0c8e-4bce-807f-437395fd3b9c" />

### 📲 QR Kod Oluşturma ve Çözümleme
> *Sistem içi QR kod yönetimi.*
<img width="1911" height="910" alt="image" src="https://github.com/user-attachments/assets/f9c03eae-4027-40bf-88dc-223311edd7d5" />


### 🍕 Menü ve Sepet Ekranı
<img width="1919" height="911" alt="image" src="https://github.com/user-attachments/assets/fcff91a9-b040-485b-8497-8cfc2302ebe8" />

<img width="1919" height="916" alt="image" src="https://github.com/user-attachments/assets/a106bb27-87f8-44fb-b5bf-d185e79c03f7" />


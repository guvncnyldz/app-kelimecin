# app-kelimecin - Kelime ezberleme uygulaması

---

## Sınıflar

### Sahne Sınıfları 

#### Scene_AddWord

Kelime eklenen sahneyi kontrol eden sınıf. Kelime eklenmesi durumunda word ile ilişki kurarak, ekleme işlemini gerçekleştirir

#### Scene_LearnedWords

Öğrenilen kelimelerin bulunduğu sahneyi kontrol eder. Dropdowndan gelen bilgiye göre labelları doldurur

#### Scene_LearningWords

Öğrenilecek kelimelerin bulunduğu sahne. Kelimelerin listesini ekrana basar.

#### Scene_Login

Uygulamanın giriş ekranı

#### Scene_Main

Uygulamanın ana menusundeki butonları kontrol eder

### Veritabanı Sınıfları

#### Db_Learned

Öğrenilmiş kelimelerin bulunduğu veritabanı tablosuna ekleme ve seçme işlemlerini yapar

#### Db_Learning

Öğrenlecek kelimelerin bulunduğu veritabanı tablosuna ekleme, silme, seçme ve güncelleme işlemlerini yapar

### Grafik Sınıfları

#### MakeGraph

Dropdowndan gelen yıla göre grafiğe girilecek olan verileri işler ve grafiğin sütunlarının boyutunu, konumunu ayarlar.

### Diğer Sınıflar 

#### Word

Kelimeyi ve kelime bilgilerini tutar

#### WordProgress

İlişki kurduğu word sınıfındaki kelimenin ilerlemesini kontrol eder. Seviye ve sorulma tarihi bilgilerini tutar
İçindeki metodlar ile seviyeye göre tarihi ayarlar.

#### LearnedWord

Öğrenilen kelimeyi ve bilgilerini tutar

#### SceneOperation

Ienumerator metodları ile sahne geçişlerini ve animasyonlarını kontrol eden, singleton kalıbı kullanılmış sınıf

#### QuestionArea

Eğer sorulacak soru var ise, sorunun sorulduğu alanı, şıkları ve sorunun cevaplanması durumunu kontrol eder

#### MakeQuestion

QuestionArea'dan çarılan MakeQuestion, ona parametre olarak gelen kelime için şıkları döndürür

#### ConnectionString

Veritabanı yolunu tutar

#### Vocabulary

Şıkların hazırlanması için kullanılan kelime haznesi

---

## Sahneler

### Giriş Ekranı

![Login](https://user-images.githubusercontent.com/26750286/58074913-0bdc7000-7baf-11e9-82a2-8b6ce691d2e9.png)

### Ana Ekran

![Main](https://user-images.githubusercontent.com/26750286/58075075-670e6280-7baf-11e9-9b4c-86e4ef4d40cb.png)

### Kelime Ekle Ekranı

![AddWord](https://user-images.githubusercontent.com/26750286/58075096-78576f00-7baf-11e9-857b-7cb702a46219.png)

### Kelimelerin Ekranı

![LearningWord](https://user-images.githubusercontent.com/26750286/58075131-93c27a00-7baf-11e9-8caf-bce3c8362530.png)

### Öğrendiğin Kelimeler Ekranı

![LearnedWord](https://user-images.githubusercontent.com/26750286/58075147-9e7d0f00-7baf-11e9-8a8c-8001971cca32.png)

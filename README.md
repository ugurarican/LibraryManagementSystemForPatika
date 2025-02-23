# LibraryManagementSystemForPatika  
## Projede İstenilenler  
MVC Projesi  
MVC PROJESİ : Kütüphane Yönetim Sistemi  
Proje Tanımı: Bir ASP.NET Core MVC uygulaması geliştirin. Bu uygulama, bir kütüphanenin kitap, yazar işlemlerini yönetmek için kapsamlı bir sistem olacaktır. Projede birden fazla model ve sayfa içerecektir.  
Proje OOP (Nesne Yönelimli Programlama) prensiplerine uygun olmalıdır.  

### Proje Gereksinimleri:  
#### Model Oluşturma:  

##### Book Modeli:  

Id: (Benzersiz kimlik, int türünde)  

Title: (Kitap başlığı, string türünde)  

AuthorId: (Yazar kimliği, int türünde, Author modeline referans)  

Genre: (Kitap türü, string türünde)  

PublishDate: (Yayın tarihi, DateTime türünde)  

ISBN: (ISBN numarası, string türünde)  

CopiesAvailable: (Mevcut kopya sayısı, int türünde)  

##### Author Modeli:  

Id: (Benzersiz kimlik, int türünde)  

FirstName: (Yazarın adı, string türünde)  

LastName: (Yazarın soyadı, string türünde)  

DateOfBirth: (Doğum tarihi, DateTime türünde)  

##### ViewModel Oluşturma:  

Kitap detaylarını ve ilgili bilgileri gösterecek bir ViewModel oluşturun. Bu ViewModel kitapların listeleneceği sayfalar için de kullanılabilir.  

Yazar detaylarını ve yazarların listeleneceği sayfalar için kullanılacak bir ViewModel oluşturun.  

##### Controller Oluşturma:  

BookController: Kitaplarla ilgili işlemleri yönetecek ve aşağıdaki aksiyon metodlarına sahip olacak:  

List: Kitapların listesini gösterir.  

Details: Belirli bir kitabın detaylarını gösterir.  

Create: Yeni bir kitap eklemek için form sağlar.  

Edit: Var olan bir kitabı düzenlemek için form sağlar.  

Delete: Kitabı silmek için bir onay sayfası sağlar.  

AuthorController: Yazarlarla ilgili işlemleri yönetecek ve aşağıdaki aksiyon metodlarına sahip olacak:  

List: Yazarların listesini gösterir.  

Details: Belirli bir yazarın detaylarını gösterir.  

Create: Yeni bir yazar eklemek için form sağlar.  

Edit: Var olan bir yazarı düzenlemek için form sağlar.  

Delete: Yazarı silmek için bir onay sayfası sağlar.  

#### View Oluşturma:  

##### Book Views:  

List: Kitapların listesini görüntüleyen bir view.  Bir buton ile silme işlemi de yapılır.  

Details: Kitap detaylarını görüntüleyen bir view.  

Create: Yeni kitap eklemek için form içeren bir view.  

Edit: Var olan kitapları düzenlemek için form içeren bir view.  

##### Author Views:  

List: Yazarların listesini görüntüleyen bir view. Bir buton ile silme işlemi de yapılır.  

Details: Yazar detaylarını görüntüleyen bir view.  

Create: Yeni yazar eklemek için form içeren bir view.  

Edit: Var olan yazarları düzenlemek için form içeren bir view.  

##### Program.cs Konfigürasyonu:  

MVC Servislerinin Eklenmesi: MVC yapılandırmalarını gerçekleştirin.  

wwwroot Kullanımı: wwwroot klasöründeki statik dosyaların kullanılmasını sağlayın.  

Routing Konfigürasyonu: İsteklerin doğru controller ve aksiyon metodlarına yönlendirilmesini sağlayın.  

Varsayılan Routing: Anasayfa için varsayılan bir routing yapılandırması ekleyin.  

###### NOTLAR:  

Projenizde Layout & en az bir PartialView kullanınız.  

Projenizde sayfanın altına sabitlenmiş, hakların size ait olduğuna dair bir yazı içeren bir footer bulunsun.  

Projenizde bulunması gereken sayfalar : Ana Sayfa - Hakkında 

## Projede Neler Yaptım?

#### İlk adım olarak Model klasörünü ve içerisinde Author ve Book için kullanılacak olan List, Edit, Details ve Add Modellerini oluşturdum. Kullanıcının yanlış veri girişini engellemek için Validationlar ekledim.  
#### Projemde static Listelerle çalıştığım için proje başladığında içerisinde default olarak gelecek Author ve Book Listelerini tutan Repository Modelini oluşturdum.
#### Http isteklerini kontrol edecek Author ve Book Controllerlarını oluşturdum. Edit, Delete, Details, List, Add actionlarını HttpGet ve HttpPost olacak şekilde düzenledim.
##### HttpPost istekleri için validationların kontrolünü sağlayıp uygun olmaması halinde ekranda doldurulmuş olan alanları geri döndürdüm.  
#### Program çalıştığında kullanıcının göreceği ilgili ekran için Author ve Book View klasörleri oluşturdum.
##### Bu klasörlerde Add, Details, Edit ve List için cshtml kodlarını ekledim. Kullanıcının yanlış veri girişinde ekranda gözükecek olan validationlar için gerekli span taglarını ekledim.  
##### View'lar içerisinde Microsoft Tag Helper yapısını kullandım.  
### Projede PartialView istendiği için Navbar ve Footer'ı PartialView haline getirdim ve Layout.cshtml içerisine ekledim.  
## NOT  
### Bir kitabın bir yazarı olduğu için foreign key olarak AuthorId tanımlandı ve kitapların yazarları Edit, Add actionlarına viewbag yardımı ile gönderildi, fakat bir yazarın birden fazla kitabı olacabileceği için ilgili Author modellerine kitaplar liste şeklinde tanımlandı.  
## Programın Ekran Görüntüleri  

#### Programın Ana Sayfası  
![AnaSayfa](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/Anasayfa.png)  

#### Kitapların Listesi  
![KitapList](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/KitapList.png)  

#### Kitap Detayı  
![KitapDetail](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/KitapDetaylar.png)  

#### Kitap Düzenleme  
![KitapEdit](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/KitapD%C3%BCzenleme-1.png)  

#### Kitap Düzenleme ve Ekleme için Validationlar  
![KitapValidation](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/KitapD%C3%BCzenlemeValidation.png)  

#### Kitap Ekleme  
![KitapAdd](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YeniKitapEkle.png)  

#### Yeni Kitap Eklenmiş Hali  
![AfterBookAdd](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/KitapEklenmi%C5%9FHali.png)  

#### Yazarların Listesi  
![AuthorList](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YazarListesi.png)  

#### Yazar Detayı  
![AuthorDetails](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YazarDetails.png)  

#### Yazar Düzenleme  
![AuthorEdit](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YazarD%C3%BCzenleme.png)  

#### Yazar Düzenleme ve Ekleme için Validationlar  
![AuthorValidation](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YazarValidation.png)  

#### Yazar Ekleme  
![AuthorAdd](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YazarEkleme.png)  

#### Yazar Eklenmiş Hali  
![AfterAuthorAdd](https://github.com/ugurarican/LibraryManagementSystemForPatika/blob/master/wwwroot/PatikaK%C3%BCt%C3%BCphane/YazarEklenmi%C5%9FHali.png)  


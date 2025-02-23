using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemForPatika.Models
{
    public class AuthorEditViewModel
    {
        [Required(ErrorMessage = "Yazar ID zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Otomatik hesaplanan özellik

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        [CustomValidation(typeof(AuthorEditViewModel), nameof(ValidateDateOfBirth))]
        public DateTime DateOfBirth { get; set; }
        public static ValidationResult ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext context)
        {
            // 1. Tarihin 01-01-1500'den büyük olup olmadığını kontrol et
            if (dateOfBirth < new DateTime(1500, 1, 1))
            {
                return new ValidationResult("Doğum tarihi 01-01-1500 tarihinden önce olamaz.");
            }

            // 2. Kullanıcının 18 yaşından büyük olup olmadığını kontrol et
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            // Ay ve gün kontrolü
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--; // Eğer doğum günü henüz gelmediyse yaştan bir çıkar
            }

            // 18 yaşından küçükse hata döndür
            if (age < 18)
            {
                return new ValidationResult("Kullanıcı 18 yaşından büyük olmalıdır.");
            }

            // 18 yaşındaysa, ay ve gün kontrolü yap
            if (age == 18)
            {
                // Doğum günü henüz gelmediyse (ay ve gün kontrolü)
                if (dateOfBirth.Date > today.AddYears(-18))
                {
                    return new ValidationResult("Kullanıcı 18 yaşından büyük olmalıdır.");
                }
            }

            // Her iki koşul da sağlanıyorsa başarılı dön
            return ValidationResult.Success;
        }
    }
}

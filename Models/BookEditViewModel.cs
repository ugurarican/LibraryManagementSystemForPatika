using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemForPatika.Models
{
    public class BookEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Ad en az 2, en fazla 200 karakter olmalıdır.")]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Tür alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad en az 2, en fazla 50 karakter olmalıdır.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Yayın tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        [CustomValidation(typeof(BookEditViewModel), nameof(ValidatePublishDate))]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "ISBN numarası zorunludur.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN numarası tam olarak 13 karakter olmalıdır.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Mevcut kopya sayısı zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Mevcut kopya sayısı 0 veya daha büyük olmalıdır.")]
        public int CopiesAvailable { get; set; }

        public static ValidationResult ValidatePublishDate(DateTime publishDate, ValidationContext context)
        {
            if (publishDate > DateTime.Now)
            {
                return new ValidationResult("Yayın tarihi gelecekte olamaz.");
            }
            return ValidationResult.Success;
        }
    }
}

namespace LibraryManagementSystemForPatika.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookAddViewModel
    {
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Ad en az 2, en fazla 200 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yazar ID alanı zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir Yazar seçiniz.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Tür alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Tür en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Yayın tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(BookAddViewModel), nameof(ValidatePublishDate))]
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

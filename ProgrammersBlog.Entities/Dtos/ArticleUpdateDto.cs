using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Tag")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [DisplayName("Aktif mi ?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin mi ?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public bool IsDeleted { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}

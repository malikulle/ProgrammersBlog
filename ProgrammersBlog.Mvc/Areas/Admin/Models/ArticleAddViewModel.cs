using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Models
{
    public class ArticleAddViewModel
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Content { get; set; }

        [DisplayName("Küçük Resim Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public IFormFile ThumbnailFile { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date { get; set; }

        [DisplayName("Yazar Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoAuthor { get; set; }

        [DisplayName("Makale Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Tag")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public int? CategoryId { get; set; }
        public bool IsActive { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class AboutUsPageInfo
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Header { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string Content { get; set; }
        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoTags { get; set; }
        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public string SeoAuthor { get; set; }
    }
}

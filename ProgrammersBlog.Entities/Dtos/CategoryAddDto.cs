using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} boş geçilemez")]
        public string Name { get; set; }
        [DisplayName("Kategori Açıklama")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public string Description { get; set; }
        [DisplayName("Kategori Not Alaı")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public string Note { get; set; }
        [DisplayName("Aktif mi ?")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public bool IsActive { get; set; }
    }
}

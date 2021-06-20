using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class EmailSendDto
    {
        [DisplayName("İsminiz")]
        [Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string Name { get; set; }
        [DisplayName("E-Posta Adresiniz")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string Email { get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string Subject { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string Message { get; set; }
    }
}

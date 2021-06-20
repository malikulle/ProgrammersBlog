using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.Models
{
    public class ArticleRightSidebarViewModel
    {
        public string Header { get; set; }        
        public ArticleListDto ArticleListDto { get; set; }
        public User User { get; set; }
    }
}

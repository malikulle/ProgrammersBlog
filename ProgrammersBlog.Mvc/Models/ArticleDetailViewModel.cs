using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.Models
{
    public class ArticleDetailViewModel
    {
        public ArticleDto ArticleDto { get; set; }
        public ArticleRightSidebarViewModel ArticleRightSidebarViewModel { get; set; }
    }
}

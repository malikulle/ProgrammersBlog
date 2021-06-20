using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Models
{
    public class CategoryUpdatejaxViewModel
    {
        public CategoryUpdateDto CategoryUpdateDto{ get; set; }

        public string CategoryUpdatePartial { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}

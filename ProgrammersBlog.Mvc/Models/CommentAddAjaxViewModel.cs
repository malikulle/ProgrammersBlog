﻿using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.Models
{
    public class CommentAddAjaxViewModel
    {
        public CommentAddDto CommentAddDto { get; set; }
        public string CommentAddPartial { get; set; }
        public CommentDto CommentDto { get; set; }
    }
}

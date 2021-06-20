﻿using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string Picture { get; set; }
        public string About { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GitHubLink { get; set; }
        public string WebsiteLink { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
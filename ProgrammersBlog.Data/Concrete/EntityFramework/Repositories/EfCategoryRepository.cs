﻿using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;

namespace ProgrammersBlog.Data.Concrete
{
    public class EfCategoryRepository : EfEntityRepository<Category> , ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
                
        }

        public async Task<Category> GetById(int CategoryId)
            => await ProgrammersBlogContext.Categories.SingleOrDefaultAsync(x => x.Id == CategoryId);

        private ProgrammersBlogContext ProgrammersBlogContext
        {
            get
            {
                return _context as  ProgrammersBlogContext;;
            }
        }
    }
}
 
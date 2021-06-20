using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepo;
        private EfCategoryRepository _categoryRepo;
        private EfCommentRepository _commentRepo;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepo ??= new EfArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepo ??= new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepo ??= new EfCommentRepository(_context);



        public async ValueTask DisposeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;
using SimplerBookCatalog.Application.Interfaces;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimplerBookCatalogDbContext _context;
        public BookRepository(IDbContextFactory<SimplerBookCatalogDbContext> factory)
        {
            _context = factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

  
        public async Task<List<Book>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
           var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
              }
        }
    }
}

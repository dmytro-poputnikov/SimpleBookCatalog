using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Infrastructure.Context;

public class SimplerBookCatalogDbContext : DbContext
{
    public SimplerBookCatalogDbContext(DbContextOptions<SimplerBookCatalogDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}

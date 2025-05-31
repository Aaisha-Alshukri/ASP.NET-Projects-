
using Microsoft.EntityFrameworkCore;
using ListApplication.Models;

namespace ListApplication.Context
{
    public class ApplicationDbContext :DbContext
    { 
      public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

       public DbSet<Category> Categorys { get; set; }
       public DbSet<ListApp> Lists { get; set; }

    }

}

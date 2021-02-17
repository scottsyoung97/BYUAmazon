using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUAmazon.Models
{
    public class SeedData
    {

        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(

                  new Book
                  {
                      title = "Les Miserables",
                      author = "Victor Hugo",
                      publisher = "Signet",
                      ISBN = "978-0451419439",
                      classification = "fiction, classic",
                      price = 9.95
                  },

                  new Book
                  {
                      title = "Team of Rivals",
                      author = "Doris Kearns Goodwin",
                      publisher = "Simon & Schuster",
                      ISBN = "978-0743270755",
                      classification = "non-fiction, biography",
                      price = 14.58
                  },

                  new Book
                  {
                       title = "The Snowball",
                       author = "Alice Schroeder",
                       publisher = "Bantam",
                       ISBN = "978-0553384611",
                       classification = "non-fiction, biography",
                       price = 21.54
                  }
                );

                context.SaveChanges();
            }
        }
    }
}

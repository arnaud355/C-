using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ApplicationDbContext : DbContext
    {
        //Constructeur vide, mais il as besoin de paramètres pour l'injection de dépendances
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
         {
            
         }

        //Point d'entrée
        public DbSet<Book> Book { get; set; }
    }
}

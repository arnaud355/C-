using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Models
{
    /*
     * il faut creer une classe et instance pour la base de données:
     * 1) Renseigner la connection dans le fichier appsettings.json:
     * "ConnectionStrings": {
            "DefaultConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=BookListMVC;Trusted_connection=True;MultipleActiveResultSets=True"
        }
        2) Dans startup ajouter dans la méthode ConfigureServices(IServiceCollection services):
     * services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
     * 
     * Installer le paquet Microsoft.EntityFrameworkCore.Sql
     * Installer Razor RuntimeCompilation
     * Installer Microsoft.EntityFrameworkCore.Tools
       Installer via la console nuget: add-migration AddBookToDb
       update-database, pour pousser notre model vers database
         */
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}

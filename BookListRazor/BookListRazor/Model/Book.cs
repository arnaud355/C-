using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book
    {
        /*After set class we install microsoft entityFrameworkCore,
        and microsoft entityframeworkCore sql server, and ...t entityframeworkCore tools with Nuget*/
        /*You need to add connection string in appsettings.json, after
        create a class (applicationDbContext) which herite from DbContext
        (using entityframeworkCore ), with constructor and entry point.
        you need to configure service in startup, and "add-migration AddBookToDb"
        in console Nuget.
        For create a database: update-database*/
        //server name: (LocalDb)\MSSQLLocalDB


        //[key] allow to create automatically key
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
    }
}

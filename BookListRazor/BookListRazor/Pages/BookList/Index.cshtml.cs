using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            /*we can extract the application db context that is inside
            the dependency injection container and inject into this page.
            
             If you did not have dependency injection, you have to create new object
             */
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }
        public void OnGet()
        {

        }
    }
}
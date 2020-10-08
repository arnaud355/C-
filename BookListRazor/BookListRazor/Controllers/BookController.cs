using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    /* Pour ajouter controller, je creer dossier, puis controller,
     * je configure dans startup:
     * services.AddControllersWithViews();
     * et plus loin:
     * endpoints.MapControllers();
     * 
     * je defini une route et un api controlle, et des methodes avec attribut Http...
     
     */
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if(bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
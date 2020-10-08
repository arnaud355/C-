using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }
        /*Le IActionResult type de retour est approprié lorsque plusieurs ActionResult types de 
          retour sont possibles dans une action.Les types ActionResult représentent différents 
          codes d’état HTTP. Toute classe non abstraite dérivant de ActionResult qualifie 
          en tant que type de retour valide.Voici quelques types de retour courants dans cette 
          catégorie : BadRequestResult (400), NotFoundResult(404) et OkObjectResult(200). 
          
          Le Task represente toute opération asynchrone*/
        public async Task<IActionResult> OnPost()
        {
            //Verifie que champs required bien remplis, server side
            if (ModelState.IsValid)
            {
                //On le lie avec BindProperty pour l'associer avec l'objet Book de la classe Book
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
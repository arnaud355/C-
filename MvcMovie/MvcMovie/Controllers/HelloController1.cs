using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // /HelloWorld/Welcome?name=Arnaud&numtimes=4
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        //https://localhost:{PORT}/HelloWorld/Welcome/3?name=Arnaud
        /*
        public string Welcome(string name, int ID = 1)
        {
            // Requires using System.Text.Encodings.Web;
            return HtmlEncoder.Default.Encode($"Hello {name}, ID is: {ID}");
            
        }*/
    }
}

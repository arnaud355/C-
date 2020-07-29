using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable <Restaurant> Restaurants { get; set; }

        /*BindProperty lie la requete http, get, du formulaire avec le paramètre
        à envoyer dans la methode GetRestaurantsByName(SearchTerm)*/
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        //config vient de la classe dont ListModel a hérité: PageModel
        public ListModel(IConfiguration config,IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
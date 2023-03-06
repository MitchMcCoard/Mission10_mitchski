using Microsoft.AspNetCore.Mvc;
using Mission10_mitchski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Components
{
    public class TypesVIewComponent : ViewComponent
    {
        private IBookstoreReposotory repo { get; set; }

        public TypesVIewComponent(IBookstoreReposotory temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            //Passing from the controller to the view which button/category was selected
            ViewBag.SelectedCategory = RouteData?.Values["category"];


            var types = repo.Books
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x);

            return View(types);
        }
    }
}

using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
namespace MyCafeWeb.Controllers
{
    public class HomeController : Controller
    {
        //Used Unity famework to reslove dependency 
        private readonly IProductsMenu ProductsMenu;
        public HomeController(IProductsMenu _productsMenu)
        {
            ProductsMenu = _productsMenu;
        }

        public ActionResult Index()
        {
           IEnumerable<MenuViewModel> menuList= ProductsMenu.GetMenu();
            return View(menuList);
        }
        //Ajax post method to calculate price
        [HttpPost]
        public string AddCart(int ProductId, string TotalAmount)
        {
            MenuViewModel product = ProductsMenu.GetProductById(ProductId);

            //decimal NewTotalAmount = Convert.ToDecimal(TotalAmount) + product.Price;

            return ProductsMenu.CalculateTotalAmount(product, Convert.ToDecimal(TotalAmount)).ToString();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class ProductsMenu : IProductsMenu
    {
        public IEnumerable<MenuViewModel> GetMenu()
        {
            //Here I can use Repository pattern instead of directly calling entity objects. 
            //So my Repository project will talk to database 
            MyCafeEntities _db = new MyCafeEntities();

          var s = (from pr in _db.Products
                                     join p in _db.Prices on pr.price_id equals p.price_id
                                     join pt in _db.ProductTypes on pr.type_id equals pt.product_type_id
                                     join ps in _db.ProductStates on pr.state_id equals ps.state_id
                                     select ( new MenuViewModel
                                     {
                                         ProductId = pr.product_id,
                                         ProductName = pr.product_name,
                                         Price = p.price1,
                                         Type = pt.description,
                                         State = ps.description,
                                         ImagePath = pr.image_path
                                     })).ToList();

            return s;
        }

        public MenuViewModel GetProductById(int ProductId)
        {
            MyCafeEntities _db = new MyCafeEntities();

            var s = (from pr in _db.Products
                     join p in _db.Prices on pr.price_id equals p.price_id
                     join pt in _db.ProductTypes on pr.type_id equals pt.product_type_id
                     join ps in _db.ProductStates on pr.state_id equals ps.state_id
                     where pr.product_id == ProductId
                     select (new MenuViewModel
                     {
                         ProductId = pr.product_id,
                         ProductName = pr.product_name,
                         Price = p.price1,
                         Type = pt.description,
                         State = ps.description,
                         ImagePath = pr.image_path
                     })).FirstOrDefault();

            return s;
        }

        public decimal CalculateTotalAmount(MenuViewModel Product, decimal OldTotalAmount)
        {
            decimal NewTotalAmount = Product.Price;
            double VatAmount = 0;

            if (Product.Type == "Cold" && Product.State == "Food")
                VatAmount = Convert.ToDouble((10 / 100) * NewTotalAmount);

            if (Product.Type == "Hot" && Product.State == "Food")
                VatAmount = Convert.ToDouble((20 / 100) * NewTotalAmount);
            
            OldTotalAmount = OldTotalAmount + NewTotalAmount + (decimal)VatAmount;
            return OldTotalAmount;
        }
    }
}

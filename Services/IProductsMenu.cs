using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    /// <summary>
    /// Getting Cafe menu from database
    /// </summary>
    public interface IProductsMenu
    {
        IEnumerable<MenuViewModel> GetMenu();
        MenuViewModel GetProductById(int ProductId);
        decimal CalculateTotalAmount(MenuViewModel Product, decimal OldTotalAmount);
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using Services;

namespace MyCafeUnitTest
{
    /// <summary>
    /// Summary description for CafeTest
    /// </summary>
    [TestClass]
    public class CafeTest
    {

        public CafeTest()
        {
           
        }
        public IProductsMenu ProductsMenu = new ProductsMenu();
        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetMenu()
        {
            IEnumerable<MenuViewModel> menuList = ProductsMenu.GetMenu();

            int expected = 0;
            
           foreach (var item in menuList)
                expected++;
            // assert  
            int actual = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetMenuById(int id)
        {
            MenuViewModel menuList = ProductsMenu.GetProductById(id);

            MenuViewModel expected = new MenuViewModel
            { ProductId =1,ImagePath= @"C:\My VS Projects\MyCafe\MyCafe\MyCafeWeb\Images\coke.jpeg",
                Price= 0.50m,ProductName= "Cola", State="Drinks",Type="Cold" };

         
            Assert.AreEqual(expected, menuList);
        }
    }
}

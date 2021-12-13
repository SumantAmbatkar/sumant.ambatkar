using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using ShopBridge.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace TestShopBridge
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void GetAllProducts_ShouldReturnAllProducts()
        {
            var controller = new ShopBridgeController();
            var result = await controller.GetProducts() as List<Product>;
            Assert.AreEqual(3, result.Count);
        }


    }
}

using ShopBridge.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class ShopBridgeController : ApiController
    {
        private ShopBridgeEntities dbShopBridge = new ShopBridgeEntities();


        [HttpGet]
        [Route("api/GetProducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dbShopBridge.Products.ToArrayAsync();
        }

        [HttpGet]
        [Route("api/GetProducts/{id}")]
        public async Task<IHttpActionResult> GetProducts(int id)
        {
            Product product = dbShopBridge.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("api/CreateProduct")]
        public async Task<IHttpActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbShopBridge.Products.Add(product);
            dbShopBridge.SaveChanges();

            return Ok(product);
        }

        [HttpPut]
        [Route("api/UpdateProduct/{id}")]
        public async Task<IHttpActionResult> UpdateProduct(long id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var productExists = dbShopBridge.Products.Where(s => s.Id == id).SingleOrDefault();

            if (productExists != null)
            {
                productExists.Name = product.Name;
                productExists.Description = product.Description;
                productExists.Price = product.Price;
                productExists.Quantity = product.Quantity;

                dbShopBridge.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/DeleteProduct/{id}")]
        public async Task<IHttpActionResult> DeleteProduct(long id)
        {
            Product product = dbShopBridge.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            dbShopBridge.Products.Remove(product);
            dbShopBridge.SaveChanges();
            return Ok();
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.db;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public class Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public int SalePrice { get; set; }
            public int Cost { get; set; }
            public int Stock { get; set; }
            public int userId { get; set; }
        }

        [HttpGet(Name = "get_products")]
        public List<Product>GetProducts()
        {
            return ADO_Products.ReturnProducts();
        }

    }
}

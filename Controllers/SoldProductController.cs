using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.db;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductController : ControllerBase
    {
        public class SoldProduct 
        {
            public int Id { get; set; }
            public string ProductId { get; set; }
            public int Stock { get; set; }
            public int SaleId { get; set; }
        }

        [HttpGet(Name = "get_soldproducts")]
        public List<SoldProduct> GetSoldProducts()
        {
            return ADO_SoldProducts.ReturnSoldProducts();
        }
    }   
}

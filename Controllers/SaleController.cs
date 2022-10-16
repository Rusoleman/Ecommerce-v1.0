using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.db;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        public class Sale
        {
            public int Id { get; set; }
            public string Comments { get; set; }
            public int UserId { get; set; }
        }

        [HttpGet(Name = "get_sales")]
        public List<Sale> GetSales()
        {
            return ADO_Sales.ReturnSales();
        }
    }
}

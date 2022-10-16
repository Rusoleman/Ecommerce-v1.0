using Microsoft.AspNetCore.Mvc;
using static Ecommerce.Controllers.ProductController;
using System.Data.SqlClient;

namespace Ecommerce.db
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADO_Products : ControllerBase
    {
        public static List<Product> ReturnProducts()
        {
            var productsList = new List<Product>();                
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Producto";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var product = new Product();                        
                    product.Id = Convert.ToInt32(reader2.GetValue(0));
                    product.ProductName = reader2.GetValue(1).ToString();
                    product.Description = reader2.GetValue(2).ToString();
                    product.SalePrice = Convert.ToInt32(reader2.GetValue(3));
                    product.Cost = Convert.ToInt32(reader2.GetValue(4));
                    product.Stock = Convert.ToInt32(reader2.GetValue(5));

                    productsList.Add(product);

                }
                reader2.Close();
                connection.Close();
            }
            return productsList;
        }
        
    }
}

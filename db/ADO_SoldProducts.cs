using static Ecommerce.Controllers.SoldProductController;

using System.Data.SqlClient;

namespace Ecommerce.db
{
    public class ADO_SoldProducts
    {
        public static List<SoldProduct> ReturnSoldProducts()
        {
            var soldProductsList = new List<SoldProduct>();

            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM ProductoVendido";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var soldProduct = new SoldProduct();

                    soldProduct.Id = Convert.ToInt32(reader2.GetValue(0));
                    soldProduct.ProductId = reader2.GetValue(1).ToString();
                    soldProduct.Stock = Convert.ToInt32(reader2.GetValue(2));
                    soldProduct.SaleId = Convert.ToInt32(reader2.GetValue(3));

                    soldProductsList.Add(soldProduct);

                }
                reader2.Close();
                connection.Close();

            }
            return soldProductsList;

        }
    }
}
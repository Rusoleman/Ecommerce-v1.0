using Microsoft.AspNetCore.Mvc;
using static Ecommerce.Controllers.SaleController;
using System.Data.SqlClient;

namespace Ecommerce.db
{
    public class ADO_Sales
    {
        public static List<Sale> ReturnSales()
        {
            var salesList = new List<Sale>();

            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Venta";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var sale = new Sale();

                    sale.Id = Convert.ToInt32(reader2.GetValue(0));
                    sale.Comments = reader2.GetValue(1).ToString();
                    sale.UserId = Convert.ToInt32(reader2.GetValue(2));

                    salesList.Add(sale);

                }
                reader2.Close();
                connection.Close();

            }
            return salesList;

        }
    }
}

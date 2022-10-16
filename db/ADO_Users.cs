using static Ecommerce.Controllers.UserController;
using System.Data.SqlClient;

namespace Ecommerce.db
{
    public class ADO_Users
    {
        public static List<User> ReturnUsers()
        {
            var usersList = new List<User>();

            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Usuario";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var user = new User();

                    user.Id = Convert.ToInt32(reader2.GetValue(0));
                    user.Name = reader2.GetValue(1).ToString();
                    user.Lastname = reader2.GetValue(2).ToString();
                    user.Username = reader2.GetValue(3).ToString();
                    user.Password = reader2.GetValue(4).ToString();
                    user.Email = reader2.GetValue(5).ToString();

                    usersList.Add(user);

                }
                reader2.Close();
                connection.Close();

            }
            return usersList;

        }
    }
}


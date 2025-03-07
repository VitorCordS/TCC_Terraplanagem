using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Terraplenagem_TCC
{
    public class Database
    {
        private string connectionString = "data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";

        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Conecte WHERE nome_user=@Username AND senha_user=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count == 1;
            }
        }
    }

}

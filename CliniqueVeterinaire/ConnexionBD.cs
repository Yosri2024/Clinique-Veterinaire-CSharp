using Microsoft.Data.SqlClient;

namespace CliniqueVeterinaire
{
    public class ConnexionBD
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CliniqueVeterinaire;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
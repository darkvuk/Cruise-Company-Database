using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class DrzavaOperations
    {
        public static List<DrzavaModel> GetDrzava(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Drzava";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<DrzavaModel> result = new List<DrzavaModel>();

                    while (reader.Read())
                    {
                        DrzavaModel drzava = new DrzavaModel();
                        drzava.Ime_drzave = reader.GetString(0);

                        result.Add(drzava);
                    }

                    connection.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

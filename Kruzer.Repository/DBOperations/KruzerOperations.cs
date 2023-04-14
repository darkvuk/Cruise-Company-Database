using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class KruzerOperations
    {
        public static List<KruzerModel> GetKruzer(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Kruzer";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<KruzerModel> result = new List<KruzerModel>();

                    while (reader.Read())
                    {
                        KruzerModel kruzer = new KruzerModel();
                        kruzer.IMO_Broj = reader.GetString(0);
                        kruzer.Ime = reader.GetString(1);
                        kruzer.Kapacitet = reader.GetInt32(2);
                        kruzer.God_gradnje = reader.GetInt32(3);
                        kruzer.Duzina = (double)reader.GetDecimal(4);
                        kruzer.Sirina = (double)reader.GetDecimal(5);
                        kruzer.Zastava = reader.GetString(6);

                        result.Add(kruzer);
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

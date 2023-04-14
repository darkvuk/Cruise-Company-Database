using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class PolOperations
    {
        public static List<PolModel> GetPol(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Pol";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<PolModel> result = new List<PolModel>();

                    while (reader.Read())
                    {
                        PolModel pol = new PolModel();
                        pol.Naziv_pola = reader.GetString(0);

                        result.Add(pol);
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

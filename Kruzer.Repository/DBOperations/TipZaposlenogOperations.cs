using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class TipZaposlenogOperations
    {

        public static List<TipZaposlenogModel> GetTipZaposlenog(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Tip_Zaposlenog";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<TipZaposlenogModel> result = new List<TipZaposlenogModel>();

                    while (reader.Read())
                    {
                        TipZaposlenogModel tip = new TipZaposlenogModel();
                        tip.Naziv_tipa = reader.GetString(0);

                        result.Add(tip);
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

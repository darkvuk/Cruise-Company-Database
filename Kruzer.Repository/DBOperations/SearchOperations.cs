using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class SearchOperations
    {
        public static List<LukaModel> GetLukaByCountry(LukaModel luka, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Luka WHERE Ime_drzave = @Drzava";
                    selectCommand.Parameters.AddWithValue("Drzava", luka.Ime_drzave);

                    SqlDataReader reader1 = selectCommand.ExecuteReader();
                    List<LukaModel> result = new List<LukaModel>();

                    while (reader1.Read())
                    {
                        LukaModel luka1 = new LukaModel();
                        luka1.KOD = reader1.GetString(0);
                        luka1.Ime_drzave = reader1.GetString(1);
                        luka1.Ime_grada = reader1.GetString(2);
                        result.Add(luka1);
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

        public static List<PutnikModel> GetPutnikByCountry(PutnikModel putnik, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Luka WHERE drzava = @Drzava";
                    selectCommand.Parameters.AddWithValue("Drzava", putnik.Drzava);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<PutnikModel> result = new List<PutnikModel>();

                    while (reader.Read())
                    {
                        PutnikModel putnik1 = new PutnikModel();
                        putnik1.ID = reader.GetInt32(0);
                        putnik1.Ime = reader.GetString(1);
                        putnik1.Prezime = reader.GetString(2);
                        putnik1.Datum_rodjenja = reader.GetDateTime(3);
                        putnik1.Br_pasosa = reader.GetString(4);
                        putnik1.Drzava = reader.GetString(5);
                        putnik1.Pol = reader.GetString(6);
                        putnik1.Email = reader.GetString(7);

                        result.Add(putnik1);
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

using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class KartaOperations
    {

        public static List<KartaModel> GetKarta(string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Karta";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<KartaModel> result = new List<KartaModel>();

                    while (reader.Read())
                    {
                        KartaModel karta = new KartaModel();
                        karta.Broj = reader.GetInt32(0);
                        karta.Cijena = reader.GetInt32(1);
                        karta.ID_Krstarenja = reader.GetInt32(2);
                        karta.ID_Putnika = reader.GetInt32(3);
                        karta.IMO_Broj = reader.GetString(4);
                        karta.ID_Kabine = reader.GetInt32(5);

                        result.Add(karta);
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

        public static List<KartaModel> GetFullKartaDetails(string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select ka.broj, ka.cijena, ka.ID_Krstarenja, p.ID, p.Ime, p.prezime, ka.IMO_Broj, kr.ime,ka.ID_Kabine " +
                                                "from karta ka, putnik p, kruzer kr where p.id = ka.id_putnika and kr.imo_broj = ka.imo_broj";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<KartaModel> result = new List<KartaModel>();

                    while (reader.Read())
                    {
                        KartaModel karta = new KartaModel();
                        karta.Broj = reader.GetInt32(0);
                        karta.Cijena = reader.GetInt32(1);
                        karta.ID_Krstarenja = reader.GetInt32(2);
                        karta.ID_Putnika = reader.GetInt32(3);
                        karta.Ime_putnika = reader.GetString(4);
                        karta.Prezime_putnika = reader.GetString(5);
                        karta.IMO_Broj = reader.GetString(6);
                        karta.Ime_kruzera = reader.GetString(7);
                        karta.ID_Kabine = reader.GetInt32(8);

                        result.Add(karta);
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

        public static KartaModel GetKartaByID(int kartaID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {

                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Karta WHERE Broj = @KartaID";
                    selectCommand.Parameters.AddWithValue("KartaID", kartaID);

                    SqlDataReader reader1 = selectCommand.ExecuteReader();
                    reader1.Read();

                    KartaModel karta = new KartaModel();

                    karta.Broj = reader1.GetInt32(0);
                    karta.Cijena = reader1.GetInt32(1);
                    karta.ID_Krstarenja = reader1.GetInt32(2);
                    karta.ID_Putnika = reader1.GetInt32(3);
                    karta.IMO_Broj = reader1.GetString(4);
                    karta.ID_Kabine = reader1.GetInt32(5);
                    connection.Close();
                    return karta;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool DeleteKarta(int kartaID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Karta WHERE " +
                                                "Broj = @TicketID";
                    deleteCommand.Parameters.AddWithValue("TicketID", kartaID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    connection.Close();
                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool InsertKarta(KartaModel karta, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = /*"SET IDENTITY_INSERT Karta ON"
                                                +*/ "insert into karta(cijena, id_krstarenja, id_putnika, imo_broj, id_kabine) "+
                                                    "values(@cijena, @id_krstarenja, @id_putnika, @imo_broj, @id_kabine)";
                                                
                    insertCommand.Parameters.AddWithValue("Cijena", karta.Cijena);
                    insertCommand.Parameters.AddWithValue("ID_Krstarenja", karta.ID_Krstarenja);
                    insertCommand.Parameters.AddWithValue("ID_putnika", karta.ID_Putnika);
                    insertCommand.Parameters.AddWithValue("IMO_Broj", karta.IMO_Broj);
                    insertCommand.Parameters.AddWithValue("ID_Kabine", karta.ID_Kabine);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateKarta(KartaModel karta, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE [Karta] " +
                                                "SET Cijena = @Cijena, "+
                                                "ID_Krstarenja = @ID_Krstarenja, " +
                                                "ID_putnika = @ID_putnika, " +
                                                "IMO_Broj = @IMO_Broj, " + 
                                                "ID_Kabine = @ID_Kabine " +
                                                "WHERE Broj = @Broj";


                    updateCommand.Parameters.AddWithValue("Cijena", karta.Cijena);
                    updateCommand.Parameters.AddWithValue("ID_Krstarenja", karta.ID_Krstarenja);
                    updateCommand.Parameters.AddWithValue("ID_putnika", karta.ID_Putnika);
                    updateCommand.Parameters.AddWithValue("IMO_Broj", karta.IMO_Broj);
                    updateCommand.Parameters.AddWithValue("ID_Kabine", karta.ID_Kabine);
                    updateCommand.Parameters.AddWithValue("Broj", karta.Broj);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

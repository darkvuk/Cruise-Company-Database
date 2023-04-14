using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class ZaposleniOperations
    {

        public static List<ZaposleniModel> GetZaposleni(string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Zaposleni";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<ZaposleniModel> result = new List<ZaposleniModel>();

                    while (reader.Read())
                    {
                        ZaposleniModel zaposleni = new ZaposleniModel();
                        zaposleni.ID = reader.GetInt32(0);
                        zaposleni.Ime = reader.GetString(1);
                        zaposleni.Prezime = reader.GetString(2);
                        zaposleni.Datum_rodjenja = reader.GetDateTime(3);
                        zaposleni.Godine_staza = reader.GetInt32(4);
                        zaposleni.Duzina_ugovora = reader.GetInt32(5);
                        zaposleni.Pozicija = reader.GetString(6);
                        zaposleni.Pol = reader.GetString(7);
                        zaposleni.Drzava = reader.GetString(8);
                        zaposleni.Kruzer = reader.GetString(9);
                        zaposleni.Plata = reader.GetInt32(10);
                        result.Add(zaposleni);
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

        public static ZaposleniModel GetZaposleniByID(int zaposleniID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Zaposleni WHERE ID = @ZaposleniID";
                    selectCommand.Parameters.AddWithValue("ZaposleniID", zaposleniID);

                    SqlDataReader reader1 = selectCommand.ExecuteReader();
                    reader1.Read();

                    ZaposleniModel zaposleni = new ZaposleniModel();

                    zaposleni.ID = reader1.GetInt32(0);
                    zaposleni.Ime = reader1.GetString(1);
                    zaposleni.Prezime = reader1.GetString(2);
                    zaposleni.Datum_rodjenja = reader1.GetDateTime(3);
                    zaposleni.Godine_staza = reader1.GetInt32(4);
                    zaposleni.Duzina_ugovora = reader1.GetInt32(5);
                    zaposleni.Pozicija = reader1.GetString(6);
                    zaposleni.Pol = reader1.GetString(7);
                    zaposleni.Drzava = reader1.GetString(8);
                    zaposleni.Kruzer = reader1.GetString(9);
                    zaposleni.Plata = reader1.GetInt32(10);

                    connection.Close();
                    return zaposleni;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        public static bool DeleteZaposleni(int zaposleniID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Zaposleni WHERE " +
                                                "ID = @ZaposleniID";
                    deleteCommand.Parameters.AddWithValue("ZaposleniID", zaposleniID);

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

        public static bool InsertZaposleni(ZaposleniModel zaposleni, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = /*"SET IDENTITY_INSERT Zaposleni ON"
                                                +*/ "INSERT INTO [Zaposleni] (Ime, Prezime, Datum_rodjenja, Godine_staza, Duzina_ugovora, Pozicija, Pol, Drzava, Kruzer, Plata) "
                                                + "VALUES (@Ime, @Prezime, @Datum_rodjenja, @Godine_staza, @Duzina_ugovora, @Pozicija, @Pol, @Drzava, @Kruzer, @Plata)";

                    //insertCommand.Parameters.AddWithValue("ID", zaposleni.ID);
                    insertCommand.Parameters.AddWithValue("Ime", zaposleni.Ime);
                    insertCommand.Parameters.AddWithValue("Prezime", zaposleni.Prezime);
                    insertCommand.Parameters.AddWithValue("Datum_rodjenja", zaposleni.Datum_rodjenja);
                    insertCommand.Parameters.AddWithValue("Godine_staza", zaposleni.Godine_staza);
                    insertCommand.Parameters.AddWithValue("Duzina_ugovora", zaposleni.Duzina_ugovora);
                    insertCommand.Parameters.AddWithValue("Pozicija", zaposleni.Pozicija);
                    insertCommand.Parameters.AddWithValue("Pol", zaposleni.Pol);
                    insertCommand.Parameters.AddWithValue("Drzava", zaposleni.Drzava);
                    insertCommand.Parameters.AddWithValue("Kruzer", zaposleni.Kruzer);
                    insertCommand.Parameters.AddWithValue("Plata", zaposleni.Plata);

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

        public static bool UpdateZaposleni(ZaposleniModel zaposleni, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE [Zaposleni] " +
                                                "SET Ime = @Ime," +
                                                "Prezime = @Prezime," +
                                                "Datum_rodjenja = @Datum_rodjenja," +
                                                "Godine_staza = @Godine_staza," +
                                                "Duzina_ugovora = @Duzina_ugovora," +
                                                "Pozicija = @Pozicija," +
                                                "Pol = @Pol," +
                                                "Drzava = @Drzava," +
                                                "Kruzer = @Kruzer," +
                                                "Plata = @Plata " +
                                                "WHERE ID = @ID";


                    updateCommand.Parameters.AddWithValue("Ime", zaposleni.Ime);
                    updateCommand.Parameters.AddWithValue("Prezime", zaposleni.Prezime);
                    updateCommand.Parameters.AddWithValue("Datum_rodjenja", zaposleni.Datum_rodjenja);
                    updateCommand.Parameters.AddWithValue("Godine_staza", zaposleni.Godine_staza);
                    updateCommand.Parameters.AddWithValue("Duzina_ugovora", zaposleni.Duzina_ugovora);
                    updateCommand.Parameters.AddWithValue("ID", zaposleni.ID);
                    updateCommand.Parameters.AddWithValue("Pozicija", zaposleni.Pozicija);
                    updateCommand.Parameters.AddWithValue("Pol", zaposleni.Pol);
                    updateCommand.Parameters.AddWithValue("Drzava", zaposleni.Drzava);
                    updateCommand.Parameters.AddWithValue("Kruzer", zaposleni.Kruzer);
                    updateCommand.Parameters.AddWithValue("Plata", zaposleni.Plata);

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

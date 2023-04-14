using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class PutnikOperations
    {
        public static List<PutnikModel> GetPutnik(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Putnik";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<PutnikModel> result = new List<PutnikModel>();

                    while (reader.Read())
                    {
                        PutnikModel putnik = new PutnikModel();
                        putnik.ID = reader.GetInt32(0);
                        putnik.Ime = reader.GetString(1);
                        putnik.Prezime = reader.GetString(2);
                        putnik.Datum_rodjenja = reader.GetDateTime(3);
                        putnik.Br_pasosa = reader.GetString(4);
                        putnik.Drzava = reader.GetString(5);
                        putnik.Pol = reader.GetString(6);
                        putnik.Email = reader.GetString(7);

                        result.Add(putnik);
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

        public static PutnikModel GetPutnikByID(int putnikID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Putnik WHERE ID = @PutnikID";
                    selectCommand.Parameters.AddWithValue("PutnikID", putnikID);

                    SqlDataReader reader1 = selectCommand.ExecuteReader();
                    reader1.Read();

                    PutnikModel putnik = new PutnikModel();

                    putnik.ID = reader1.GetInt32(0);
                    putnik.Ime = reader1.GetString(1);
                    putnik.Prezime = reader1.GetString(2);
                    putnik.Datum_rodjenja = reader1.GetDateTime(3);
                    putnik.Br_pasosa = reader1.GetString(4);
                    putnik.Drzava = reader1.GetString(5);
                    putnik.Pol = reader1.GetString(6);
                    putnik.Email = reader1.GetString(7);

                    connection.Close();
                    return putnik;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        public static bool DeletePutnik(int putnikID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Putnik WHERE " +
                                                "ID = @PutnikID";
                    deleteCommand.Parameters.AddWithValue("PutnikID", putnikID);

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

        public static bool InsertPutnik(PutnikModel putnik, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = /*"SET IDENTITY_INSERT Putnik ON"
                                                +*/ "INSERT INTO [Putnik] (Ime, Prezime, Datum_rodjenja, Br_pasosa, Drzava, Pol, Email) "
                                                + "VALUES (@Ime, @Prezime, @Datum, @Br_pasosa, @Drzava, @Pol, @Email)";

                    //insertCommand.Parameters.AddWithValue("ID", putnik.ID);
                    insertCommand.Parameters.AddWithValue("Ime", putnik.Ime);
                    insertCommand.Parameters.AddWithValue("Prezime", putnik.Prezime);
                    insertCommand.Parameters.AddWithValue("Datum", putnik.Datum_rodjenja);
                    insertCommand.Parameters.AddWithValue("Br_pasosa", putnik.Br_pasosa);
                    insertCommand.Parameters.AddWithValue("Drzava", putnik.Drzava);
                    insertCommand.Parameters.AddWithValue("Pol", putnik.Pol);
                    insertCommand.Parameters.AddWithValue("Email", putnik.Email);

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

        public static bool UpdatePutnik(PutnikModel putnik, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE [Putnik] " +
                                                "SET Ime = @Ime, " +
                                                "Prezime = @Prezime, " +
                                                "Datum_rodjenja = @Datum_rodjenja, " +
                                                "Br_pasosa = @Br_pasosa, " +
                                                "Drzava = @Drzava, " +
                                                "Pol = @Pol, " +
                                                "Email = @Email " +
                                                "WHERE ID = @ID";


                    updateCommand.Parameters.AddWithValue("Ime", putnik.Ime);
                    updateCommand.Parameters.AddWithValue("Prezime", putnik.Prezime);
                    updateCommand.Parameters.AddWithValue("Datum_rodjenja", putnik.Datum_rodjenja);
                    updateCommand.Parameters.AddWithValue("Br_pasosa", putnik.Br_pasosa);
                    updateCommand.Parameters.AddWithValue("Drzava", putnik.Drzava);
                    updateCommand.Parameters.AddWithValue("Pol", putnik.Pol);
                    updateCommand.Parameters.AddWithValue("Email", putnik.Email);
                    updateCommand.Parameters.AddWithValue("ID", putnik.ID);

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

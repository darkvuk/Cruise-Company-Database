using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class RegisterOperations
    {

        public static List<KorisnikModel> GetKorisnik(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM korisnik";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<KorisnikModel> result = new List<KorisnikModel>();

                    while (reader.Read())
                    {
                        KorisnikModel user = new KorisnikModel();
                        user.Name = reader.GetString(0);
                        user.Surname = reader.GetString(1);
                        user.Username = reader.GetString(2);
                        user.Password = reader.GetString(3);
                        user.isAdmin = reader.GetInt32(4);
                        result.Add(user);
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
        public static bool InsertKorisnik(KorisnikModel korisnik, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO[KORISNIK](Name, Surname, Username, Password, isAdmin)" +
                                                "VALUES(@Name, @Surname, @Username, @Password, @isAdmin)";

                    insertCommand.Parameters.AddWithValue("Name", korisnik.Name);
                    insertCommand.Parameters.AddWithValue("Surname", korisnik.Surname);
                    insertCommand.Parameters.AddWithValue("Username", korisnik.Username);
                    insertCommand.Parameters.AddWithValue("Password", korisnik.Password);
                    insertCommand.Parameters.AddWithValue("isAdmin", 0);

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

    }
}

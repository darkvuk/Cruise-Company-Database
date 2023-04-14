using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class KorisnikOperations
    {

        public static KorisnikModel Login(KorisnikModel korisnik, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand userCommand = new SqlCommand();
                    userCommand.CommandText = "SELECT * FROM Korisnik WHERE Username = @Username AND Password = @Password";
                    userCommand.Connection = connection;

                    userCommand.Parameters.AddWithValue("Username", korisnik.Username);
                    userCommand.Parameters.AddWithValue("Password", korisnik.Password);

                    SqlDataReader reader = userCommand.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    } else
                    {
                        korisnik.Name = reader.GetString(0);
                        korisnik.Surname = reader.GetString(1);
                        korisnik.Username = reader.GetString(2);
                        korisnik.Password = reader.GetString(3);
                        korisnik.isAdmin = reader.GetInt32(4);

                    }

                    connection.Close();
                    return korisnik;


                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        
        public static bool Register(KorisnikModel korisnik, string connectionString)
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
                    insertCommand.Parameters.AddWithValue("isAdmin", korisnik.isAdmin);

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

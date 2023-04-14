using Kruzer.Repository.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruzer.Repository.DBOperations
{
    public class LukaOperations
    {
        public static List<LukaModel> GetLuka(string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Luka";

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    List<LukaModel> result = new List<LukaModel>();

                    while (reader.Read())
                    {
                        LukaModel luka = new LukaModel();
                        luka.KOD = reader.GetString(0);
                        luka.Ime_drzave = reader.GetString(1);
                        luka.Ime_grada = reader.GetString(2);
                        result.Add(luka);
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

        public static LukaModel GetLukaByID(String lukaID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Luka WHERE KOD = @LukaID";
                    selectCommand.Parameters.AddWithValue("LukaID", lukaID);

                    SqlDataReader reader1 = selectCommand.ExecuteReader();
                    reader1.Read();

                    LukaModel luka = new LukaModel();

                    
                        luka.KOD = reader1.GetString(0);
                        luka.Ime_drzave = reader1.GetString(1);
                        luka.Ime_grada = reader1.GetString(2);

                        connection.Close();
                        return luka;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        public static bool DeleteLuka(string lukaID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Luka WHERE " +
                                                "KOD = @LukaID";
                    deleteCommand.Parameters.AddWithValue("LukaID", lukaID);

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

        public static bool InsertLuka(LukaModel luka, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = /*"SET IDENTITY_INSERT Luka ON"
                                                +*/ "INSERT INTO [Luka] (KOD, Ime_drzave, Ime_grada) "
                                                + "VALUES (@KOD, @Ime_drzave, @Ime_grada)";

                    insertCommand.Parameters.AddWithValue("KOD", luka.KOD);
                    insertCommand.Parameters.AddWithValue("Ime_drzave", luka.Ime_drzave);
                    insertCommand.Parameters.AddWithValue("Ime_grada", luka.Ime_grada);

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
        //--------------------------
        public static bool UpdateLuka(LukaModel luka, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE [Luka] " +
                                                "SET Ime_drzave = @Ime_drzave, " +
                                                "Ime_grada = @Ime_grada " +
                                                "WHERE KOD = @KOD";


                    updateCommand.Parameters.AddWithValue("KOD", luka.KOD);
                    updateCommand.Parameters.AddWithValue("Ime_drzave", luka.Ime_drzave);
                    updateCommand.Parameters.AddWithValue("Ime_grada", luka.Ime_grada);

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

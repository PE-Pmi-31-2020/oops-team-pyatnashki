using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=FiveOurs;Integrated Security=True";
            CreateDatabase();
            WriteData(connectionString);
            ReadData(connectionString);
            Console.Read();
        }


        static void CreateDatabase()
        {
            SqlConnection con = new SqlConnection
                (@"Data Source=localhost\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
            string createDatabaseQuery =
                            "IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'FiveOurs')" +
                            "BEGIN\n" +
                            "CREATE DATABASE FiveOurs\n" +
                            "END\n";
            SqlCommand cmd = new SqlCommand(createDatabaseQuery, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Creating database script executed successfully.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }

            string createTableQuery =
                            "USE FiveOurs\n" +
                            "IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='Results' and xtype='U')\n" +
                            "BEGIN\n" +
                            "CREATE TABLE Results(\n" +
                            "res_id INT PRIMARY KEY IDENTITY(1, 1),\n" +
                            "player_name VARCHAR(50) NOT NULL,\n" +
                            "game_time INT NOT NULL,\n" +
                            "number_of_moves INT NOT NULL\n" +
                            ")\n" +
                            "END\n";
            cmd = new SqlCommand(createTableQuery, con);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Creating table script executed successfully.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }

            con.Close();
        }

        static void ReadData(string connectionString)
        {
            string sqlExpression = "SELECT * FROM Results";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object time = reader.GetValue(2);
                        object numberOfMoves = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, name, time, numberOfMoves);
                    }
                }

                reader.Close();
            }
        }

        static void WriteData(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int n = 50;
                for (int i = 0; i < n; i++)
                {
                    Random rnd = new Random();
                    string name = "player" + System.Convert.ToString(i);
                    int time = rnd.Next(400);
                    int moves = rnd.Next(600);
                    string cmd = $"INSERT INTO Results (player_name, game_time, number_of_moves) VALUES ('{name}', {time}, {moves})";
                    SqlCommand command = new SqlCommand(cmd, connection);

                    command.ExecuteNonQuery();
                }

            }

        }

    }
}

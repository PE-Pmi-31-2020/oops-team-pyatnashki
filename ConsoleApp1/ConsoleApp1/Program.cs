using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER02;Initial Catalog=FiveOurs;User Id = sa;Password = Aa1234567890";

            ReadData(connectionString);
            

            Console.Read();
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
    }
}

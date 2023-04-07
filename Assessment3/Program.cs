using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Assessment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tables.Create();
            //Program.AddSport("volleyball");
            //Program.AddSport("football");
            //Program.AddSport("baseball");
            //Program.AddSport("handball");
            //Program.RemoveSport("handball");
            //Program.AddPlayer();

        }

        public static void AddSport(string sportName)
        {
            //Adding a Sport in sports table

            using(SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();
                
                string insertQuery = "INSERT INTO sports (sports_name) VALUES(@sportName)";

                SqlCommand command = new SqlCommand(insertQuery, sqlConnection);
                command.Parameters.AddWithValue("@sportName", sportName);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public static void RemoveSport( string sportName)
        {
            //Removing a Sport from the Sports List;
            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                string insertQuery = "DELETE FROM sports WHERE sports_name = @sportName;";

                SqlCommand command = new SqlCommand(insertQuery, sqlConnection);
                command.Parameters.AddWithValue("@sportName", sportName);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        public static void AddPlayer()
        {
            //Adding a Player 

            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                // Getting the input from the user
                Console.Write("Enter the Player Name : ");
                string playerName = Console.ReadLine()!;
                int sportId;

                sqlConnection.Open();

                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "SELECT * from sports";
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("In the list of available sports, select the sport by entering its corresponding number... ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(1)} - {reader.GetInt32(0)}");
                    }
                    sportId = Convert.ToInt32(Console.ReadLine());

                }
                sqlConnection.Close();

                sqlConnection.Open();

                string insertQuery = "INSERT INTO players (player_name, player_sport_id) VALUES(@playerName, @sportId)";


                SqlCommand insert = new SqlCommand(insertQuery, sqlConnection);
                insert.Parameters.AddWithValue("@playerName", playerName);
                insert.Parameters.AddWithValue("@sportId", sportId);
                insert.ExecuteNonQuery();
                Console.WriteLine("Player Added Successfully!");
            }
        }
        public static void AddTournament() 
        {
            //Adding a Tournament
            Console.Write("Enter the Tournament Name : ");
            string tournamentName = Console.ReadLine()!;
            Console.Write("Enter the College Name : ");
            string collegeName = Console.ReadLine()!;
        }
    }
}
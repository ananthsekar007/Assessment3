using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public class Tables
    {
        public static void Create()
        {
            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Sports DB
                int num = DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE sports(sports_id INT IDENTITY(1, 1) PRIMARY KEY, sports_name VARCHAR(255) NOT NULL);");
                Console.WriteLine(num);
                sqlConnection.Close();
            }

            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Tournaments DB
                DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE tournaments (tournament_id INT IDENTITY(1,1) PRIMARY KEY,tournament_name VARCHAR(100) NOT NULL,college_name VARCHAR(100) NOT NULL,);");

                sqlConnection.Close();
            }

            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Rounds DB
                DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE rounds (round_id INT IDENTITY(1,1) PRIMARY KEY, round_number INT NOT NULL, tournament_id INT NOT NULL, FOREIGN KEY (tournament_id) REFERENCES tournaments (tournament_id));");

                sqlConnection.Close();
            }

            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Tournament Sports DB
                DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE tournament_sports (tournament_sport_id INT IDENTITY(1,1) PRIMARY KEY, tournament_id INT NOT NULL, sport_id INT NOT NULL, FOREIGN KEY (tournament_id) REFERENCES tournaments (tournament_id), FOREIGN KEY (sport_id) REFERENCES sports (sports_id));");

                sqlConnection.Close();
            }


            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Players DB
                DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE players (player_id INT IDENTITY(1,1) PRIMARY KEY, player_name VARCHAR(100) NOT NULL, player_sport_id INT NOT NULL, FOREIGN KEY (player_sport_id) REFERENCES sports (sports_id));");

                sqlConnection.Close();
            }

            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Players DB
                DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE scores (score_id INT IDENTITY(1,1) PRIMARY KEY, tournament_id INT NOT NULL, player_id INT NOT NULL, round_id INT NOT NULL, score INT NOT NULL, FOREIGN KEY (tournament_id) REFERENCES Tournaments (tournament_id), FOREIGN KEY (player_id) REFERENCES players (player_id), FOREIGN KEY (round_id) REFERENCES rounds (round_id));");

                sqlConnection.Close();
            }

            using (SqlConnection sqlConnection = new DbConnection().conn)
            {
                sqlConnection.Open();

                // Create Players DB
                DbConnection.ExecuteNonQuery(sqlConnection, "CREATE TABLE scoreboards ( scoreboard_id INT IDENTITY(1,1) PRIMARY KEY, tournament_id INT NOT NULL, sport_id INT NOT NULL, round_id INT NOT NULL, winner_id INT NULL, FOREIGN KEY (tournament_id) REFERENCES tournaments (tournament_id), FOREIGN KEY (sport_id) REFERENCES sports (sports_id),  FOREIGN KEY (round_id) REFERENCES rounds (round_id),  FOREIGN KEY (winner_id) REFERENCES players(player_id));  ");

                sqlConnection.Close();
            }
        }
    }
}

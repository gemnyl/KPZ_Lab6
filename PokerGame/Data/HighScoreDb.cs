using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using PokerGame.Models;
using PokerGame.ViewModels;

namespace PokerGame.Data
{
    public class HighScoreDb : BaseViewModel
    {
        // Рядковий проп для відображення складності
        public static string Dif { get; set; }

        // Отримує значення складності int і переводить у рядок
        public static void GetDifficulty()
        {
            if (Global.Difficulty == 1)
            {
                Dif = "Hard";
            }
            else if (Global.Difficulty == 2)
            {
                Dif = "Medium";
            }
            else if (Global.Difficulty == 3)
            {
                Dif = "Easy";
            }
        }

        // Встановлює найвищий бал у базі даних відповідно до гравця та обраної їм складності
        public static void SetHighscore()
        {
            GetDifficulty();

            string stmt = $"INSERT INTO highscore(score, player_id, difficulty) VALUES (@score, @player_id, @difficulty)";

            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@score", Global.EndScore);
                command.Parameters.AddWithValue("@player_id", Global.MyPlayer.PlayerId);
                command.Parameters.AddWithValue("@difficulty", Dif);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Global.EndScore = (int)reader["score"];
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Couldn´t add highscore", ex);
            }
        }

        // Отримує колекцію з бази даних для EndView на основі складності, на якій гравець грав
        public static ObservableCollection<Highscore> GetHighscores()
        {
            string stmt = $"SELECT TOP 20 player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = '{Dif}'";

            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                EndOfGameViewModel.HighscoreList = new ObservableCollection<Highscore>();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    EndOfGameViewModel.HighscoreList.Add(highscore);

                }
                return EndOfGameViewModel.HighscoreList;

            }
            catch (SqlException ex)
            {

                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        // Отримує спостережувану колекцію з бази даних для StartView/HighscoreView з високими балами на легкій складності
        public static ObservableCollection<Highscore> GetEasyHighScore()
        {
            string stmt = "SELECT TOP 20 player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Easy'";

            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> easyList = new();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]

                    };
                    easyList.Add(highscore);
                }
                return easyList;
            }
            catch (SqlException ex)
            {

                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        public static ObservableCollection<Highscore> GetMediumHighScore()
        {
            string stmt = "SELECT TOP 20 player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Medium'";

            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> mediumList = new();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    mediumList.Add(highscore);
                }
                return mediumList;
            }
            catch (SqlException ex)
            {

                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        public static ObservableCollection<Highscore> GetHardHighScore()
        {
            string stmt = "SELECT TOP 20 player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Hard'";

            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> hardList = new();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    hardList.Add(highscore);
                }
                return hardList;
            }
            catch (SqlException ex)
            {

                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        public static void ClearAllHighscores()
        {
            string stmt = $"DELETE FROM highscore";

            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Couldn't clear highscores", ex);
            }
        }
    }
}

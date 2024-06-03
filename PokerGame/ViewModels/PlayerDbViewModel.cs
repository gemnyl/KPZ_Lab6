using PokerGame.Commands;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PokerGame.Models;

namespace PokerGame.ViewModels
{
    public class PlayerDbViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public PlayerDbViewModel()
        {
            GetPlayers();
            UpdateViewAndSaveDataCommand = new UpdateViewAndSaveDataCommand(this);
            CreatePlayerCommand = new CreatePlayerCommand(this);
            DeletePlayerCommand = new DeletePlayerCommand(this);
            DifficultyDictionary[1] = "Висока - 1 роздача";
            DifficultyDictionary[2] = "Середня - 2 роздачі";
            DifficultyDictionary[3] = "Легка - 3 роздачі";
            RulesCommand = new RulesCommand(this);
            HighScoreListsCommand = new HighScoreListsCommand(this);
        }

        private ObservableCollection<Player> _players;
        public ObservableCollection<Player> Players
        {
            get => _players;
            set
            {
                if (_players != value)
                {
                    _players = value;
                    OnPropertyChanged();
                }
            }
        }
        private Player _selectedPlayer;
        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                if (_selectedPlayer != value)
                {
                    _selectedPlayer = value;
                    OnPropertyChanged();
                }
            }
        }
        public Dictionary<int, string> DifficultyDictionary { get; set; } = new Dictionary<int, string>();
        private int _selectedDifficulty;
        public int SelectedDifficulty
        {
            get => _selectedDifficulty;
            set
            {
                if (_selectedDifficulty != value)
                {
                    _selectedDifficulty = value;
                    OnPropertyChanged();
                }
            }
        }
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                if (_selectedViewModel != value)
                {
                    _selectedViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand UpdateViewAndSaveDataCommand { get; set; }
        public ICommand CreatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        private string _newPlayer;
        public string NewPlayer
        {
            get => _newPlayer;
            set
            {
                if (_newPlayer != value)
                {
                    _newPlayer = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _feedbackString;
        public string FeedbackString
        {
            get => _feedbackString;
            set
            {
                if (_feedbackString != value)
                {
                    _feedbackString = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand RulesCommand { get; set; }
        public ICommand HighScoreListsCommand { get; set; }

        // Отримує видиму колекцію створених гравців з бази даних для відображення у вікні списку на StartView для вибору користувача
        public ObservableCollection<Player> GetPlayers()
        {
            string stmt = "SELECT * FROM player ORDER BY name ASC";

            try
            {
                Players = new ObservableCollection<Player>();
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Player player = null;
                    player = new Player
                    {
                        Name = (string)reader["name"],
                        PlayerId = (int)reader["id"]
                    };
                    Players.Add(player);
                }
                return Players;
            }
            catch (SqlException ex)
            {
                string errorcode = ex.Number.ToString();
                throw new Exception("Couldn´t retrieve Players list", ex);
            }
        }

        public Player SelectPlayer(string NewPlayer)
        {
            Player player = null;
            string stmt = "SELECT * FROM player WHERE name = @name";
            try
            {
                using var conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new SqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@name", NewPlayer);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    player = new Player
                    {
                        PlayerId = (int)reader["id"],
                        Name = (string)reader["name"],
                    };
                }
                return player;
            }
            catch (SqlException ex)
            {
                string errorcode = ex.Number.ToString();
                throw new Exception("Player couldn´t be selected", ex);
            }
        }

        // Метод для створення та збереження нового гравця в базі даних
        public void CreatePlayer(string NewPlayer)
        {
            FeedbackString = null;
            string stmt = $"INSERT INTO player(name) VALUES (@name)";
            if (!string.IsNullOrEmpty(NewPlayer))
            {
                try
                {
                    using var conn = new SqlConnection(Global.ConnectionString);
                    conn.Open();

                    using var command = new SqlCommand(stmt, conn);
                    command.Parameters.AddWithValue("@name", NewPlayer);

                    command.ExecuteNonQuery();

                    FeedbackString = $"{NewPlayer} створений та обраний для гри!";
                }
                catch (SqlException ex)
                {
                    string errorcode = ex.Number.ToString();
                    FeedbackString = "Ой, такий нікнейм вже існує. Виберіть, будь-ласка, інший :)";
                }
                var player = SelectPlayer(NewPlayer);
                Global.MyPlayer = player;
                SelectedPlayer = player;
            }
            else
            {
                FeedbackString = "Ви не ввели нікнейм, або ж використали неприпустимі символи. Спробуйте ще раз.";
            }
        }

        public void DeletePlayer(Player playerToDelete)
        {
            if (playerToDelete != null)
            {
                FeedbackString = null;
                string stmt = $"DELETE FROM player WHERE id = @id";

                try
                {
                    using var conn = new SqlConnection(Global.ConnectionString);
                    conn.Open();

                    using var command = new SqlCommand(stmt, conn);
                    command.Parameters.AddWithValue("@id", playerToDelete.PlayerId);

                    command.ExecuteNonQuery();

                    FeedbackString = $"Гравець {playerToDelete.Name} успішно видалений!";
                }
                catch (SqlException ex)
                {
                    string errorcode = ex.Number.ToString();
                    FeedbackString = "Ой, сталася помилка під час видалення гравця.";
                }

                // Знайдіть нового гравця для вибору, якщо поточний гравець був видалений
                if (SelectedPlayer == playerToDelete)
                {
                    SelectedPlayer = Players.FirstOrDefault();
                    if (SelectedPlayer != null)
                    {
                        Global.MyPlayer = SelectedPlayer;
                    }
                }
            }
            else
            {
                FeedbackString = "Ви не обрали гравця для видалення.";
            }
        }

    }
}

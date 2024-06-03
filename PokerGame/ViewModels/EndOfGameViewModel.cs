using PokerGame.Commands;
using PokerGame.Views;
using PokerGame.Data;
using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerGame.ViewModels
{
    public class EndOfGameViewModel : BaseViewModel
    {
        private string _endScore;
        private string _endHand;
        public static string ShowDifficulty { get { return HighScoreDb.Dif; } set { HighScoreDb.Dif = value; } }
        public HighScoreDb highScoreDb = new();
        public static ObservableCollection<Highscore> HighscoreList { get; set; }
        public ICommand PlayAgainCommand { get; set; }
        public ICommand GoToStartCommand { get; set; }
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                if (_selectedViewModel != value)
                {
                    _selectedViewModel = value;
                    OnPropertyChanged(nameof(SelectedViewModel));
                }
            }
        }
        public ObservableCollection<CardView> FinalHand { get; set; }


        public string EndScore
        {
            get => _endScore;
            set
            {
                if (_endScore != value)
                {
                    _endScore = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EndHand
        {
            get => _endHand;
            set
            {
                if (_endHand != value)
                {
                    _endHand = value;
                    OnPropertyChanged();
                }
            }
        }

        public EndOfGameViewModel()
        {
            FinalHand = Global.FinalHand;
            HighScoreDb.SetHighscore();
            HighScoreDb.GetHighscores();
            EndScore = Global.EndScore.ToString();
            EndHand = Global.EndHand.ToString();
            PlayAgainCommand = new PlayAgainCommand(this);
            GoToStartCommand = new GoToStartCommand(this);
        }
    }
}

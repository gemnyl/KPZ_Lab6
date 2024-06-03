using PokerGame.Commands;
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
    public class HighScoreViewModel : BaseViewModel
    {
        public ICommand ReturnToStartCommand { get; set; }
        public ICommand ClearHighscoresCommand { get; set; }
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
        public HighScoreDb HighScoreDb { get; set; } = new HighScoreDb();
        private ObservableCollection<Highscore> _highscoreListHard;
        public ObservableCollection<Highscore> HighscoreListHard
        {
            get => _highscoreListHard;
            set
            {
                if (_highscoreListHard != value)
                {
                    _highscoreListHard = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Highscore> _highscoreListMedium;
        public ObservableCollection<Highscore> HighscoreListMedium
        {
            get => _highscoreListMedium;
            set
            {
                if (_highscoreListMedium != value)
                {
                    _highscoreListMedium = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Highscore> _highscoreListEasy;
        public ObservableCollection<Highscore> HighscoreListEasy
        {
            get => _highscoreListEasy;
            set
            {
                if (_highscoreListEasy != value)
                {
                    _highscoreListEasy = value;
                    OnPropertyChanged();
                }
            }
        }

        public HighScoreViewModel()
        {
            ReturnToStartCommand = new ReturnToStartCommand(this);
            ClearHighscoresCommand = new ClearHighscoresCommand(this);
            HighscoreListEasy = HighScoreDb.GetEasyHighScore();
            HighscoreListMedium = HighScoreDb.GetMediumHighScore();
            HighscoreListHard = HighScoreDb.GetHardHighScore();
        }

    }
}

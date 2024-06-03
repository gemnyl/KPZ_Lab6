using PokerGame.Commands;
using PokerGame.Data;
using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerGame.ViewModels
{
    public partial class GameViewModel : BaseViewModel
    {
        public GameEngine DeckOfCards { get; set; } = new GameEngine();
        public HowToPlayViewModel HowToPlayViewModel { get; set; } = new HowToPlayViewModel();
        private bool _isButtonEnabled;
        private string _isCardEnabled;
        public ICommand RemoveCardCommand { get; set; }
        public ICommand DrawCardCommand { get; set; }
        public int NumberOfDraws { get; set; }
        public Player SetPlayer { get; set; }
        public ICommand EndViewCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public HighScoreDb HighScoreDb { get; set; } = new HighScoreDb();
        public bool IsButtonEnabled
        {
            get => _isButtonEnabled;
            set
            {
                if (_isButtonEnabled != value)
                {
                    _isButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        public string IsCardEnabled
        {
            get => _isCardEnabled;
            set
            {
                if (_isCardEnabled != value)
                {
                    _isCardEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _combinationName;
        private int _score;
        private int _remainingAttempts;

        public string CombinationName
        {
            get => _combinationName;
            set
            {
                if (_combinationName != value)
                {
                    _combinationName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CombinationName));

                }
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Score));
                }
            }
        }

        public int RemainingAttempts
        {
            get => _remainingAttempts;
            set
            {
                if (_remainingAttempts != value)
                {
                    _remainingAttempts = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(RemainingAttempts));

                }
            }
        }
        public GameViewModel()
        {
            RemoveCardCommand = new RemoveCardCommand(this);
            DrawCardCommand = new DrawCardCommand(this);
            EndViewCommand = new EndViewCommand(this);
            DeckOfCards.GameDataUpdated += OnGameDataUpdated;
            IsCardEnabled = CardEnabler();
            OnGameDataUpdated(this, new EventArgs());
        }


        private void OnGameDataUpdated(object sender, EventArgs e)
        {
            IsCardEnabled = CardEnabler();
            CombinationName = DeckOfCards.PokerHands.CurrentPokerHand.ToString();
            Score = DeckOfCards.PokerHands.Score;
            RemainingAttempts = DeckOfCards.DrawsLeft;

            OnPropertyChanged(nameof(IsCardEnabled));
            OnPropertyChanged(nameof(CombinationName));
            OnPropertyChanged(nameof(Score));
            OnPropertyChanged(nameof(RemainingAttempts));
        }


        public string CardEnabler()
        {
            if (DeckOfCards.IsHandFiveOrLess() == true)
            {
                return "/Resources/ImagesCards/CardBack.png";
            }
            else
            {
                return "/Resources/ImagesCards/CardBackDisabled.png";
            }
        }

        public static bool CheckIfHighScore()
        {
            foreach (var item in HighScoreDb.GetHighscores())
            {
                if (Global.EndScore >= item.Score)
                {
                    return true;
                }
            }

            return false;
        }

        public void ExecuteGameOver()
        {
            if (DeckOfCards.CanDrawNewCard() == false)
            {
                Global.FinalHand = DeckOfCards.CardViews;
                Task.Delay(1000).ContinueWith(t => EndViewCommand.Execute(this));
            }
        }

        public static void PlaySoundBasedOnScore()
        {
            if (CheckIfHighScore() == true)
            {
                Global.PlayHighScoreSound();
            }
            else if (Global.EndScore >= 5)
            {
                Global.PlayPointsSound();
            }
            else
            {
                Global.PlayNoPointsSound();
            }
        }
    }
}

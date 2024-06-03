using PokerGame.Data;
using PokerGame.Models;
using PokerGame.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;

namespace PokerGame.Commands
{
    class ClearHighscoresCommand : ICommand
    {
        private readonly HighScoreViewModel highScoreViewModel;

        public ClearHighscoresCommand(HighScoreViewModel highScoreViewModel)
        {
            this.highScoreViewModel = highScoreViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Global.PlayClickSound();
            HighScoreDb.ClearAllHighscores();
            highScoreViewModel.HighscoreListEasy = HighScoreDb.GetEasyHighScore();
            highScoreViewModel.HighscoreListMedium = HighScoreDb.GetMediumHighScore();
            highScoreViewModel.HighscoreListHard = HighScoreDb.GetHardHighScore();
        }
    }
}


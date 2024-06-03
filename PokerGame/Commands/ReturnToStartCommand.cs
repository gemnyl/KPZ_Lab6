using PokerGame.Data;
using PokerGame.Models;
using PokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerGame.Commands
{
    class ReturnToStartCommand : ICommand
    {
        private readonly HighScoreViewModel highScoreViewModel;

        public ReturnToStartCommand(HighScoreViewModel highScoreViewModel)
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
            highScoreViewModel.SelectedViewModel = new PlayerDbViewModel();
        }
    }
}


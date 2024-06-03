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
    class HighScoreListsCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;

        public HighScoreListsCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
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
            playerDb.SelectedViewModel = new HighScoreViewModel();
        }
    }
}


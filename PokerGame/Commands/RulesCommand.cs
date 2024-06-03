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
    class RulesCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;

        public RulesCommand(PlayerDbViewModel playerDb)
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
            playerDb.SelectedViewModel = new HowToPlayViewModel();
            Global.PlayClickSound();
        }
    }
}

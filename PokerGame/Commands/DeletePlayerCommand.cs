using PokerGame.Views;
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
    class DeletePlayerCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;
        private StartView startView;

        public DeletePlayerCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
        }

        public DeletePlayerCommand(StartView startView)
        {
            this.startView = startView;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            playerDb.DeletePlayer(playerDb.SelectedPlayer);
            playerDb.GetPlayers();
            Global.PlayClickSound();
        }
    }
}


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
    class CreatePlayerCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;

        public CreatePlayerCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            playerDb.CreatePlayer(playerDb.NewPlayer);
            playerDb.GetPlayers();
            Global.PlayClickSound();
        }
    }
}

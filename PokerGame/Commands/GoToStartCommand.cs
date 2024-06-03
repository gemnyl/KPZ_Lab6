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
    class GoToStartCommand : ICommand
    {
        private readonly EndOfGameViewModel endOfGameViewModel;


        public GoToStartCommand(EndOfGameViewModel endOfGameViewModel)
        {
            this.endOfGameViewModel = endOfGameViewModel;

        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Повертає гравця на стартовий екран
        /// <param name="parameter"></param>
        /// </summary>
        public void Execute(object parameter)
        {
            endOfGameViewModel.SelectedViewModel = new PlayerDbViewModel();
            Global.PlayClickSound();
        }

    }
}

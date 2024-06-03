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
    class PlayAgainCommand : ICommand
    {
        private readonly EndOfGameViewModel endOfGameViewModel;

        public PlayAgainCommand(EndOfGameViewModel endOfGameViewModel)
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
        /// Повертає гравця до GameView, щоб він міг зіграти ще раз. Це відбувається шляхом простого встановлення SelectedViewModel на нову GameViewModel.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            endOfGameViewModel.SelectedViewModel = new GameViewModel();
            Global.PlayClickSound();
        }
    }
}

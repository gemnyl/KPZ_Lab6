using PokerGame.Views;
using PokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerGame.Commands
{
    public class RemoveCardCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;

        public RemoveCardCommand(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// При виконанні видаляє вибраний CardView з ObservableCollection.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var cardView = (CardView)parameter;
            gameViewModel.DeckOfCards.CardViews.Remove(cardView);
        }

    }
}

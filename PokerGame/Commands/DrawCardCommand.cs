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
    public class DrawCardCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;

        public DrawCardCommand(GameViewModel gameViewModel)
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
        /// Роздає нові карти з колоди.
        /// Створює новий CardViews, який відображає карти для гравця.
        /// Очищає колекцію спостережуваних карт ThrownCards, щоб вони були видалені з гри.
        /// Встановлює IsEnable кнопки шляхом запуску методу.
        /// Встановлює картинку на кнопці залежно від того, чи може гравець взяти карту (залежно від карт на руці), чи ні.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Global.PlayDrawCardSound();
            gameViewModel.DeckOfCards.DrawsLeft--;
            gameViewModel.DeckOfCards.DealCards();
            gameViewModel.DeckOfCards.ThrownCards.Clear();
            gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.IsHandFiveOrLess();
            gameViewModel.IsCardEnabled = gameViewModel.CardEnabler();
            gameViewModel.ExecuteGameOver();
        }

    }
}

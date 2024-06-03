using PokerGame.Data;
using PokerGame.Models;
using PokerGame.ViewModels;
using System;
using System.Windows.Input;

namespace PokerGame.Commands
{
    class EndViewCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;

        public EndViewCommand(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Переводить гравця на вікно результатів, зберігає результат гравця і встановлює його у глобальну властивість, яка використовується на екрані результатів.
        /// <param name="parameter"></param>
        /// </summary>
        public void Execute(object parameter)
        {

            Global.FinalHand = gameViewModel.DeckOfCards.CardViews;
            Global.EndScore = gameViewModel.DeckOfCards.PokerHands.Score;
            Global.EndHand = gameViewModel.DeckOfCards.PokerHands.CurrentPokerHand.ToString();

            // Update the SelectedViewModel with OnPropertyChanged
            gameViewModel.SelectedViewModel = new EndOfGameViewModel();
            gameViewModel.OnPropertyChanged(nameof(gameViewModel.SelectedViewModel));

            GameViewModel.PlaySoundBasedOnScore();
        }
    }
}

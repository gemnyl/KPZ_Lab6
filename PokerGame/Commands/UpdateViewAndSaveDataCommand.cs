using PokerGame.Views;
using PokerGame.Models;
using PokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PokerGame.Commands
{
    class UpdateViewAndSaveDataCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;

        public UpdateViewAndSaveDataCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Метод виконується при натисканні кнопки, яка прив'язана до цієї команди. Спочатку перевіряє, чи є гравець і вибрана складність, якщо ні, то повертає користувачеві зворотній зв'язок.
        /// В іншому випадку встановлює складність у глобальну властивість, яку можна використовувати скрізь, так само як і для вибраного гравця.
        /// Оновлює модель перегляду, коли встановлює SelectedViewModel на нову GameViewModel();
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Global.PlayClickSound();
            if (playerDb.SelectedPlayer == null || playerDb.SelectedDifficulty == 0)
            {
                playerDb.FeedbackString = "Гравець та рівень складності мають бути вибраними!";
            }
            else
            {
                Global.Difficulty = playerDb.SelectedDifficulty;
                Global.MyPlayer = playerDb.SelectedPlayer;
                playerDb.SelectedViewModel = new GameViewModel();
            }
        }

    }
}

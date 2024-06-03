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
    class RestartCommand : ICommand
    {
        private readonly HowToPlayViewModel howToPlayViewModel;

        public RestartCommand(HowToPlayViewModel howToPlayViewModel)
        {
            this.howToPlayViewModel = howToPlayViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Перезавантажує гру та виводить початкове меню
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            howToPlayViewModel.SelectedViewModel = new PlayerDbViewModel();
            Global.PlayClickSound();
        }
    }
}

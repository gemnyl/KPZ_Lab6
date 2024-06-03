using PokerGame.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private PlayerDbViewModel _currentViewModel = new PlayerDbViewModel();

        public PlayerDbViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

using PokerGame.Data;
using PokerGame.ViewModels;
using PokerGame.Views;
using System.Windows;

namespace PokerGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        
    }
}

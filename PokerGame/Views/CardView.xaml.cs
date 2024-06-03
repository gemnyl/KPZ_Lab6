using PokerGame.Models;
using PokerGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static PokerGame.Models.Card;

namespace PokerGame.Views
{
    public partial class CardView : MasterGameView
    {
        public Card GetCard
        {
            get { return (Card)GetValue(GetCardProperty); }
            set { SetValue(GetCardProperty, value); }
        }


        public static readonly DependencyProperty GetCardProperty =
            DependencyProperty.Register("GetCard", typeof(Card), typeof(CardView), new PropertyMetadata(new Card()));

        protected void MoveCard(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(this, new DataObject(DataFormats.Serializable, this), DragDropEffects.Move);
            }
        }

        public CardView()
        {
            InitializeComponent();
        }

    }
}

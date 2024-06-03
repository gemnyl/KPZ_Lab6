using PokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Models
{
    public class Card : BaseViewModel
    {
        // Enum кожної масті
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades,
        }
        // Enum кожного значення в колоді карт
        public enum Value
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace,
        }

        public Suit Cardsuit { get; set; }
        public Value Cardvalue { get; set; }

        // Повертає конвертоване значення карти у вигляді рядку
        public override string ToString()
        {
            return $"{Cardsuit} {Cardvalue}";
        }

    }
}

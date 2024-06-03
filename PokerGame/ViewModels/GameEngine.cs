using PokerGame.Data;
using PokerGame.Views;
using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.ViewModels
{
    public class GameEngine : BaseViewModel
    {
        public delegate void GameDataUpdatedEventHandler(object sender, EventArgs e);
        public event GameDataUpdatedEventHandler GameDataUpdated;

        private static readonly Random random = new Random();

        public ObservableCollection<Card> Deck { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<CardView> CardViews { get; set; }
        public ObservableCollection<CardView> ThrownCards { get; set; } = new ObservableCollection<CardView>();
        public PokerHands PokerHands { get; set; } = new PokerHands();
        public int SelectedDifficulty { get; set; }
        public int NumberOfThrows { get; set; }
        public int DrawsLeft { get; set; } = Global.Difficulty;

        public GameEngine()
        {
            GameDataUpdated?.Invoke(this, new EventArgs());
            CardViews = new ObservableCollection<CardView>();
            SetUpDeck();
            DealCards();
            CreateCardViews();
            SelectedDifficulty = Global.Difficulty;
        }

        public void SetUpDeck()
        {
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Value v in Enum.GetValues(typeof(Card.Value)))
                {
                    var newcard = new Card { Cardsuit = s, Cardvalue = v };
                    Deck.Add(newcard);
                }
            }
            GameDataUpdated?.Invoke(this, new EventArgs());

        }

        public void DealCards()
        {
            do
            {
                int randomNr = random.Next(Deck.Count);
                var newCard = Deck[randomNr];
                Hand.Add(newCard);
                Deck.RemoveAt(randomNr);
            } while (Hand.Count <= 4);
            EvaluateHand.CheckPokerHand(Hand, PokerHands);
            IsHandFiveOrLess();
            NumberOfThrows++;

            GameDataUpdated?.Invoke(this, new EventArgs());

            CreateCardViews();
        }

        public void ThrowCard(int cardViewNumber)
        {
            Hand.RemoveAt(cardViewNumber);
            IsHandFiveOrLess();

            GameDataUpdated?.Invoke(this, new EventArgs());

            CreateCardViews();
        }

        public void CreateCardViews()
        {
            CardViews.Clear();
            foreach (Card card in Hand)
            {
                CardView cardView = new CardView();
                cardView.GetCard = card;
                CardViews.Add(cardView);
            }
        }

        public bool IsHandFiveOrLess()
        {
            if (Hand.Count < 5)
            {
                return true;
            }
            return false;

        }

        public bool CanDrawNewCard()
        {
            if (NumberOfThrows >= SelectedDifficulty + 1)
            {
                return false;
            }
            return true;
        }

        public static Card RecreateCardFromCardView(CardView cardView)
        {
            var suit = cardView.GetCard.Cardsuit;
            var value = cardView.GetCard.Cardvalue;

            Card card = new Card()
            {
                Cardsuit = suit,
                Cardvalue = value
            };
            return card;
        }
    }
}

using PokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PokerGame.Models.Card;

namespace PokerGame.Models
{
    public class EvaluateHand : BaseViewModel
    {
        public static bool CheckPokerHand(ObservableCollection<Card> hand, PokerHands pokerHands) // Checks all methods, and starts with the one that gives most points, and stops and give score when it finds the correct one.
        {


            if (IsFlush(hand) && IsStraight(hand))
            {
                if (IsRoyalFlush(hand))
                {
                    pokerHands.CurrentPokerHand = PokerHands.PokerHand.RoyalFlush;
                    pokerHands.Score = 50;
                    return true;
                }
            }
            if (IsFlush(hand) && IsStraight(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.StraightFlush;
                pokerHands.Score = 40;
                return true;
            }
            if (IsFourOfAKind(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.FourOfAKind;
                pokerHands.Score = 35;
                return true;
            }
            if (IsFullHouse(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.FullHouse;
                pokerHands.Score = 30;
                return true;
            }
            if (IsFlush(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.Flush;
                pokerHands.Score = 25;
                return true;
            }
            if (IsStraight(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.Straight;
                pokerHands.Score = 20;
                return true;
            }
            if (IsThree(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.ThreeOfAKind;
                pokerHands.Score = 15;
                return true;
            }
            if (IsTwoPair(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.TwoPair;
                pokerHands.Score = 10;
                return true;
            }
            if (IsPair(hand))
            {
                pokerHands.CurrentPokerHand = PokerHands.PokerHand.Pair;
                pokerHands.Score = 5;
                return true;
            }
            pokerHands.CurrentPokerHand = PokerHands.PokerHand.Nothing;
            pokerHands.Score = 0;
            return false;
        }



        public static bool IsPair(ObservableCollection<Card> hand) // sorts the hand by Cardvalue low to high, and checks if index 0 and 1 or 1-2 or 2-3 or 3-4 to see if a pair exists, dont need to check index 0 and 4, because the cards are sorted by value 
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool pair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue || (int)hand[1].Cardvalue == (int)hand[2].Cardvalue ||
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue || (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return pair;
        }

        public static bool IsTwoPair(ObservableCollection<Card> hand) // checks if the hand contains Two Pair.
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool twoPair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue && (int)hand[2].Cardvalue == (int)hand[3].Cardvalue ||
                        (int)hand[0].Cardvalue == (int)hand[1].Cardvalue && (int)hand[3].Cardvalue == (int)hand[4].Cardvalue ||
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue && (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return twoPair;
        }

        public static bool IsThree(ObservableCollection<Card> hand) // checks if the hand contains Three cards of the same CardValue.
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool threeOfAKind = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue ||

                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue ||

                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return threeOfAKind;
        }

        public static bool IsStraight(ObservableCollection<Card> hand) // checks if the hand contains five cards where CardValue are in sequential order
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool straight = (int)hand[0].Cardvalue % 13 == (int)hand[1].Cardvalue % 13 - 1 &&
                            (int)hand[1].Cardvalue % 13 == (int)hand[2].Cardvalue % 13 - 1 &&
                            (int)hand[2].Cardvalue % 13 == (int)hand[3].Cardvalue % 13 - 1 &&
                            (int)hand[3].Cardvalue % 13 == (int)hand[4].Cardvalue % 13 - 1;

            return straight;
        }

        public static bool IsFlush(ObservableCollection<Card> hand) // checks if the all the cards in the hand are of the same Cardsuit.
        {
            bool flush = (int)hand[0].Cardsuit == (int)hand[1].Cardsuit && (int)hand[1].Cardsuit == (int)hand[2].Cardsuit &&
                        (int)hand[2].Cardsuit == (int)hand[3].Cardsuit && (int)hand[3].Cardsuit == (int)hand[4].Cardsuit &&
                        (int)hand[4].Cardsuit == (int)hand[0].Cardsuit;

            return flush;
        }
        public static bool IsFullHouse(ObservableCollection<Card> hand) // checks if the cards in hand contains, three of the same value and two other cards with same value
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool fullHouse = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue ||

                        (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return fullHouse;
        }
        public static bool IsRoyalFlush(ObservableCollection<Card> hand) // checks if the cards in the hand are of value, ten,jack,queen,king,ace
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool royalFlush = hand[0].Cardvalue == Value.Ten && hand[1].Cardvalue == Value.Jack && hand[2].Cardvalue == Value.Queen && hand[3].Cardvalue == Value.King && hand[4].Cardvalue == Value.Ace;

            return royalFlush;
        }

        public static bool IsFourOfAKind(ObservableCollection<Card> hand) // checks if the hand contains four cards with the same Cardvalue
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool fourOfAKind = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue && (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue || (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return fourOfAKind;
        }

    }
}
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        public List<Card> setCards = new List<Card>();
        public Deck()
        {
            string[] suits = {"Hearts", "Diamonds", "Spades", "Clubs"};
            string[] stringValues = {"Ace", "1","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            int[] integerValues = {1,2,3,4,5,6,7,8,9,10,11,12,13};
            for(int i = 0; i < suits.Length; i++)
            {
                for(int j = 0; j < stringValues.Length; j++)
                {
                    Card card = new Card();
                    card.stringVal = stringValues[j];
                    card.val = integerValues[j];
                    card.suit = suits[i];
                    cards.Add(card);
                    setCards.Add(card);
                }
            }
        }
        public Card Deal()
        {
            Card dealtCard = cards[0];
            cards.RemoveAt(0);
            return dealtCard;
        }
        public void Reset()
        {
            for(var i = 0; i < setCards.Count; i++)
            {
        
            }
        }
    }
}
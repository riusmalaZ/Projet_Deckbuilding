using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList
{
    public static List<Card> Deck;
    public Card Draw()
    {
        Card cardDrawn = Deck[0];
        Deck.RemoveAt(0);
        return cardDrawn;
    }

    public List<Card> Draw(int count){
        List<Card> cardDrawn = new ();
        for (int i = 0; i < count; i++)
        {
            cardDrawn.Add(Draw());
        }
        return cardDrawn;
    }

    public void Shuffle()
    {
        List<Card> deckShuffled = new List<Card>();
        while (Deck.Count > 0)
        {
            int nRand = Random.Range(0, Deck.Count);
            deckShuffled.Add(Deck[nRand]);
            Deck.RemoveAt(nRand);
        }
        Deck = deckShuffled;
    }

    public void Add(Card cardToAdd)
    {
        Deck.Add(cardToAdd);
    }
    public void AddThenShuffle (Card[] cardsToAdd)
    {
        foreach(Card n in cardsToAdd)
        {
            Add(n);
        }
        Shuffle();
    }

    public Card Peek(){
        return Deck[0];
    }
    public Card Peek(int index)
    {
        try{
        return Deck[index];
        }catch{
            return Deck[0];
        }
    }

    public bool HasCard(string cardName)
    {
        foreach (Card n in Deck)
        {
            if (n.Name == cardName) return true;
        }
        return false;
    }
}
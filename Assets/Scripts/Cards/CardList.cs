using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public List<GameObject> Cards;
    public virtual GameObject Draw()
    {
        if (Cards.Count == 0)   
            return null;
        GameObject cardDrawn = Cards[0];
        Cards.RemoveAt(0);
        return cardDrawn;
    }

    public List<GameObject> Draw(int count){
        List<GameObject> cardDrawn = new ();
        for (int i = 0; i < count; i++)
        {
            cardDrawn.Add(Draw());
        }
        return cardDrawn;
    }

    public void Shuffle()
    {
        List<GameObject> cardsShuffled = new ();
        while (Cards.Count > 0)
        {
            int nRand = Random.Range(0, Cards.Count);
            cardsShuffled.Add(Cards[nRand]);
            Cards.RemoveAt(nRand);
        }
        Cards = cardsShuffled;
    }

    public void Add(params GameObject[] cardToAdd)
    {
        Cards.AddRange(cardToAdd);
    }

    public GameObject Peek(List<GameObject> Cards){
        return Cards[0];
    }
    public GameObject Peek(int index, List<GameObject> Cards)
    {
        try{
        return Cards[index];
        }catch{
            return Cards[0];
        }
    }
}
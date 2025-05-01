using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    
    public GameObject Draw(List<GameObject> Cards)
    {
        GameObject cardDrawn = Cards[0];
        Cards.RemoveAt(0);
        return cardDrawn;
    }

    public List<GameObject> Draw(int count, List<GameObject> Cards){
        List<GameObject> cardDrawn = new ();
        for (int i = 0; i < count; i++)
        {
            cardDrawn.Add(Draw(Cards));
        }
        return cardDrawn;
    }

    public List<GameObject> Shuffle(List<GameObject> CardsToSuffle)
    {
        List<GameObject> cardsShuffled = new ();
        while (CardsToSuffle.Count > 0)
        {
            int nRand = Random.Range(0, CardsToSuffle.Count);
            cardsShuffled.Add(CardsToSuffle[nRand]);
            CardsToSuffle.RemoveAt(nRand);
        }
        return cardsShuffled;
    }

    public void Add(GameObject cardToAdd, List<GameObject> Cards)
    {
        Cards.Add(cardToAdd);
    }
    public void AddThenShuffle (GameObject[] cardsToAdd, List<GameObject> Cards)
    {
        foreach(GameObject n in cardsToAdd)
        {
            Add(n, Cards);
        }
        Shuffle(Cards);
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
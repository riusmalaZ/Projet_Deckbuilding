using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    public List<GameObject> pioche = new();
    public List<GameObject> deck = new();
    public List<GameObject> main = new();
    public List<GameObject> defausse = new();
    
    
    

    // Update is called once per frame
    void Update()
    {
       pioche = PickZone.CardsInPick;
       deck = DeckManager.Deck;
       main = HandManager.CardsInHand;
       defausse = DiscardZone.DiscardedCards;
    }
}

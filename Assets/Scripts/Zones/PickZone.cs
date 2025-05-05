using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PickZone : CardList
{
    //[SerializeField] PlayerData _playerData;
    public static List<GameObject> CardsInPick = new();

    void Start()
    {
        
    }
    public void ResetPick()
    {
        int n = DiscardZone.DiscardedCards.Count;
        for (int i = 0; i < n; i++)
        {
            CardsInPick.Add(DiscardZone.DiscardedCards[0]);
            DiscardZone.DiscardedCards[0].SetActive(false);
            DiscardZone.DiscardedCards[0].GetComponent<CardsHandling>().played = false;
            
            DiscardZone.DiscardedCards.RemoveAt(0);
            
        }
        CardsInPick = Shuffle(CardsInPick);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class AllyArmy : MonoBehaviour
{
    public static List<Card> Deck = new();
    
    void Start()
    {
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        if (Deck.Count == 0)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

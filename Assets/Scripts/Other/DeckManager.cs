using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckManager : CardList
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject _cardPrefab;
    



    void Start()
    {
        InitializeDeck();
        SetupDeck();
    }

    void InitializeDeck()
    {
        if (_playerData.ActualDeck.Count == 0)
        {
            _playerData.ActualDeck = _playerData.ClassSelected.BaseDeck;
            _playerData.CP = _playerData.ClassSelected.BaseCP;
            _playerData.MaxAP = _playerData.ClassSelected.BaseAP; 
        }
    }

    void SetupDeck()
    {
        GameObject newCard;
        for (int i = 0; i < _playerData.ActualDeck.Count; i++)
        {
            newCard = Instantiate(_cardPrefab, Vector3.zero, Quaternion.identity, transform);
            CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();
            cardDisplay.CardData = _playerData.ActualDeck[i];
            cardDisplay.UpdateCardDisplay();
            newCard.name = cardDisplay.NameText.text;
            Zones.Instance.Pick.Add(newCard);
            newCard.SetActive(false);
        }

        Zones.Instance.Pick.Shuffle();
    }
}

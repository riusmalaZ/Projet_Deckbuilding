using System;
using System.Collections.Generic;
using UnityEngine;

//Adrien si t'arrives a voir ce message OUI j'ai eu la flemme de commenter 32 scripts, désolé
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;
    public PlayerData PlayerData;
    public int Difficulty;
    [SerializeField] GameObject _cardPrefab;
    public List<EnemyData> Enemies;


    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (GraphHolder.Instance.CurrentNode == null)
            FirstFight();
        else
        {
            Difficulty = GraphHolder.Instance.CurrentNode.Layer / 2;
            InitFight();
        }

    }

    void FirstFight()
    {
        Difficulty = 0;
        PlayerData.CP = PlayerData.ClassSelected.BaseCP;
        PlayerData.APBoostActive = false;
        PlayerData.ActualDeck = new(PlayerData.ClassSelected.BaseDeck);
        PlayerData.CP = PlayerData.ClassSelected.BaseCP;
        PlayerData.MaxAP = PlayerData.ClassSelected.BaseAP;
        InitFight();
    }

    void InitFight()
    {
        EnnemyArmy.Instance.EnemyData = Enemies[Difficulty];
        EnnemyArmy.Instance.InitArmy();
        SetupDeck();
    }

    void SetupDeck()
    {
        GameObject newCard;
        for (int i = 0; i < PlayerData.ActualDeck.Count; i++)
        {
            newCard = Instantiate(_cardPrefab, Vector3.zero, Quaternion.identity, transform);
            CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();
            cardDisplay.CardData = PlayerData.ActualDeck[i];
            cardDisplay.UpdateCardDisplay();
            newCard.name = cardDisplay.NameText.text;
            Zones.Instance.Pick.Add(newCard);
            newCard.SetActive(false);
        }

        Zones.Instance.Pick.Shuffle();
    }
}

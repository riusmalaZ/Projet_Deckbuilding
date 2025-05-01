using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum BuffTiming { ThisTurn, NextTurn }
    public static TurnManager Instance;
    public PlayerData playerData; 
    [HideInInspector] public List<BuffEffect> activeBuffsThisTurn = new();
    [HideInInspector] public List<BuffEffect> buffsForNextTurn = new();
    [SerializeField] HandManager _handManager;
    int currentAP;
    

    
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
    }

    public void RegisterBuff(BuffEffect effect, bool thisTurn)
    {
        if (thisTurn)
            activeBuffsThisTurn.Add(effect);
        else 
            buffsForNextTurn.Add(effect);
    }

    public void StartAllyTurn()
    {
        _handManager.AddCardsToHand(5);
        currentAP = playerData.MaxAP;

        //Les buffs qui étaient enregistrés pour le tour d'après vont s'appliquer ce tour-ci 
        activeBuffsThisTurn = new List<BuffEffect>(buffsForNextTurn);
        buffsForNextTurn.Clear();
        //APPLIQUER LES BUFFS


        
    }

    public void EndAllyTurn()
    {
        activeBuffsThisTurn.Clear();
        foreach (GameObject card in HandManager.CardsInHand)
        {
            
        }
    }

    public int GetModifiedValue(Card card, BuffEffect.TargetStat stat, int baseValue)
    {
        int modifiedValue = baseValue;

        foreach (var buff in activeBuffsThisTurn)
        {
            //if (buff.statToModify == stat && buff.Affects(card))
                modifiedValue += buff.amount;
        }

        return Mathf.Max(0, modifiedValue); // Évite un coût négatif par exemple
    }
}

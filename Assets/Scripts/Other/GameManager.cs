using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData; 
    public List<BuffEffect> activeBuffsThisTurn = new();
    public List<BuffEffect> buffsForNextTurn = new();
    int currentAP;
    

    
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterTemporaryBuff(BuffEffect effect)
    {
        activeBuffsThisTurn.Add(effect);
    }

    public void RegisterNextTurnBuff(BuffEffect effect)
    {
        buffsForNextTurn.Add(effect);
    }

    public void StartAllyTurn()
    {
        currentAP = playerData.MaxAP;

        //Les buffs qui étaient enregistrés pour le tour d'après vont s'appliquer ce tour-ci 
        activeBuffsThisTurn = new List<BuffEffect>(buffsForNextTurn);
        buffsForNextTurn.Clear();
    }

    public void EndAllyTurn()
    {
        activeBuffsThisTurn.Clear();
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

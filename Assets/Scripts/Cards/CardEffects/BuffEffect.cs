using System;
using UnityEngine;

[System.Serializable]
public class BuffEffect : ICardEffect
{
    public enum TargetStat { Cost, Damage, Defense }
    public TargetStat statToModify;
    //ThisTurn == true -> buff appliqué ce tour, == false -> appliqué au prochain tour 
    public bool ThisTurn ;
    public int amount;

    public bool affectAttackCards;
    public bool affectDefenseCards;
    public int duration;
    public string newCardDescription;

    public void Play()
    {
        Debug.Log("Buff appliqué");

    }

}
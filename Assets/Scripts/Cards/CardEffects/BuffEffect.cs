using System;
using UnityEngine;

[System.Serializable]
public class BuffEffect : ICardEffect
{
    public enum TargetStat { Cost, Damage, Defense, Card }
    public TargetStat statToModify;
    public int amount;

    public bool AffectAttackCards, AffectDefenseCards;

    public void Play()
    {
        TurnManager.Instance.BuffHand(this);

    }
    public void Buff(int i)
    {}

    public new ICardEffect.CardEffect GetType()
    {
        return ICardEffect.CardEffect.Buff;
    }

    public int GetAmount()
    {
        return amount;
    }
}
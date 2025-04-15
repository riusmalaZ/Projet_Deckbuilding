using System;
using UnityEngine;

public class BuffEffect : ICardEffect
{
    public enum TargetStat { Cost, Damage, Defense }
    public enum BuffTiming { ThisTurn, NextTurn }

    public TargetStat statToModify;
    public int amount;

    public bool affectAttackCards;
    public bool affectDefenseCards;

    public BuffTiming timing;
    public int duration;
    public string newCardDescription;

    public void Play()
    {
        Debug.Log($"Buff temporaire : {statToModify} modifié de {amount} sur cartes " +
                  $"{(affectAttackCards ? "d’attaque " : "")}{(affectDefenseCards ? "de défense" : "")} pour ce tour.");

        GameManager.Instance.RegisterTemporaryBuff(this);

        switch (timing)
        {
            case BuffTiming.ThisTurn:
                GameManager.Instance.RegisterTemporaryBuff(this);
                break;

            case BuffTiming.NextTurn:
                GameManager.Instance.RegisterNextTurnBuff(this);
                break;
        }
    }

    /*public bool Affects(Card card)
    {
        bool isAttack = card.HasEffect<DamageEffect>();
        bool isDefense = card.HasEffect<DefenseEffect>();
        return (affectAttackCards && isAttack) || (affectDefenseCards && isDefense);
    }*/
}
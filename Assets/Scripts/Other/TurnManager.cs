using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum BuffTiming { ThisTurn, NextTurn }
    public static TurnManager Instance;
    public PlayerData playerData;
    public static bool PlayerTurn;
    [HideInInspector] public BuffEffect activeBuff;
    [SerializeField] HandManager _handManager;
    [SerializeField] Transform _discardZone;
    AllyArmy _allyArmy;
    EnnemyArmy _ennemyArmy;
    public List<Card> AttackCards;
    public List<Card> DefenseCards;


    void Start()
    {
        PlayerTurn = false;
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _allyArmy = AllyArmy.Instance;
        _ennemyArmy = EnnemyArmy.Instance;
        activeBuff = null;
    }


    public void StartAllyTurn()
    {
        if (PlayerTurn)
            return;

        _ennemyArmy.ShowNextAction();
        PlayerTurn = true;
        _handManager.AddCardsToHand(5);
        _allyArmy.AP = _allyArmy.APMax;
        if (playerData.APBoostActive) _allyArmy.AP += 1;
        _allyArmy.UpdateAPTxt();
    }

    public void EndAllyTurn()
    {
        if (!PlayerTurn)
            return;

        PlayerTurn = false;

        int nCardsInHand = Zones.Instance.Hand.Cards.Count;
        for (int i = 0; i < nCardsInHand; i++)
        {
            Zones.Instance.Hand.Cards[0].gameObject.GetComponent<CardsHandling>().Discard(_discardZone);
        }

        _ennemyArmy.Play();
    }
    public void BuffHand(BuffEffect newBuff)
    {
        activeBuff = newBuff;
        if (activeBuff.statToModify == BuffEffect.TargetStat.Card)
        {
            _handManager.AddCardsToHand(activeBuff.amount);
        }

        if (activeBuff.AffectAttackCards)
            {
                foreach (var cardData in AttackCards)
                {
                    if (activeBuff.statToModify == BuffEffect.TargetStat.Damage)
                        cardData.Effects[0].Buff(activeBuff.amount);
                    if (activeBuff.statToModify == BuffEffect.TargetStat.Cost)
                    {
                        cardData.APCost += activeBuff.amount;
                    }
                }
            }
        if (activeBuff.AffectDefenseCards)
        {
            foreach (var cardData in DefenseCards)
            {
                if (activeBuff.statToModify == BuffEffect.TargetStat.Defense)
                    cardData.Effects[0].Buff(activeBuff.amount);
                if (activeBuff.statToModify == BuffEffect.TargetStat.Cost)
                {
                    cardData.APCost += activeBuff.amount;
                }
            }
        }
        foreach (var card in Zones.Instance.Hand.Cards)
        {
            card.GetComponent<CardDisplay>().UpdateCardDisplay();
        }
    }

    public void DebuffHand()
    {
        if (activeBuff != null)
        {
            activeBuff.amount *= -1;
            BuffHand(activeBuff);
            activeBuff.amount *= -1;
            activeBuff = null;
        }
    }
}

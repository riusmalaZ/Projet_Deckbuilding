using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum BuffTiming { ThisTurn, NextTurn }
    public static TurnManager Instance;
    public PlayerData playerData; 
    public static bool PlayerTurn;
    [HideInInspector] public List<BuffEffect> activeBuffsThisTurn = new();
    [HideInInspector] public List<BuffEffect> buffsForNextTurn = new();
    [SerializeField] HandManager _handManager;
    [SerializeField] Transform _discardZone;
    AllyArmy _allyArmy;
    EnnemyArmy _ennemyArmy;
    

    
    void Start()
    {
        PlayerTurn = false;
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        _allyArmy = AllyArmy.Instance;
        _ennemyArmy = EnnemyArmy.Instance;
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
        if (PlayerTurn)
            return;
        
        _ennemyArmy.ShowNextAction();
        PlayerTurn = true;
        _handManager.AddCardsToHand(5);
        _allyArmy.AP = _allyArmy.APMax;
        _allyArmy.UpdateAPTxt(); 

        //Les buffs qui étaient enregistrés pour le tour d'après vont s'appliquer ce tour-ci 
        activeBuffsThisTurn = new List<BuffEffect>(buffsForNextTurn);
        buffsForNextTurn.Clear();
        //APPLIQUER LES BUFFS


        
    }

    public void EndAllyTurn()
    {
        if (!PlayerTurn)
            return;
        PlayerTurn = false;
        activeBuffsThisTurn.Clear();
        int nCardsInHand = Zones.Instance.Hand.Cards.Count;
        for (int i = 0; i < nCardsInHand; i++)
        {
            Zones.Instance.Hand.Cards[0].gameObject.GetComponent<CardsHandling>().Discard(_discardZone);
        }

        _ennemyArmy.NextAction.Play();
    }

}

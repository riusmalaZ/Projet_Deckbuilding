using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public CardType cardType;
    public int defenseAmount;
    public int damage;
    public int cost;
    //public Effect effect;

    public enum CardType
    {
        Attack,
        Spell,
        Power
    }

    /*public enum Effect
    {
        None,
        Spell,
        Power
    }*/

}
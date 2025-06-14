using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string CardName;
    public int APCost;
    public Sprite CardSprite;
    public string CardDescription;

    public enum CardType { Attack, Defense, Buff }
    public CardType cardType;

    [SerializeReference, SubclassSelector]
    public List<ICardEffect> Effects;

}
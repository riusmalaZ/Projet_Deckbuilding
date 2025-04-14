using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string CardName;
    public int Cost;
    public Sprite CardSprite;
    public string CardDescription;
    [SerializeReference, SubclassSelector]
    public List<ICardEffect> Effects;

}
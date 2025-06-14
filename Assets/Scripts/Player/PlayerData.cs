using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data")]
public class PlayerData : ScriptableObject
{
    public Class ClassSelected;
    public List<Card> ActualDeck;
    public int CP;
    public int MaxAP;
    public bool APBoostActive;

}

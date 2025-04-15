using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "Class")]
public class Class : ScriptableObject
{
    public List<Card> BaseDeck;
    public int BaseAP;
}
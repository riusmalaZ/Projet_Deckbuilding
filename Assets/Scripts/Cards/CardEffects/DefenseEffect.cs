using UnityEngine;

[System.Serializable]
public class DefenseEffect : ICardEffect
{
    public int Defense;
    public void Play()
    {
        Debug.Log(Defense + " Block added");
    }
}
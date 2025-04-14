using UnityEngine;

[System.Serializable]
public class DamageEffect : ICardEffect
{
    public int Damage;
    public void Play()
    {
        Debug.Log(Damage + " Damages dealt");
    }
}
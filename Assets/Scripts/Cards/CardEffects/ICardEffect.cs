using UnityEngine;

public interface ICardEffect
{
    public enum CardEffect{Defense, Damage, Buff}
    void Play();
    void Buff(int amount);
    CardEffect GetType();
    int GetAmount();
} 

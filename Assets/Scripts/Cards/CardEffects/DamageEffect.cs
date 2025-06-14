using UnityEngine;

[System.Serializable]
public class DamageEffect : ICardEffect
{
    public int Damage;
    public enum Target { Player, Ennemy }
    public void Play()
    {
        if (TurnManager.PlayerTurn)
            EnnemyArmy.Instance.Hit(Damage);

        else
            AllyArmy.Instance.Hit(Damage);
    }
    public void Buff(int amount)
    {
        Damage += amount;
    }
    public new ICardEffect.CardEffect GetType()
    {
        return ICardEffect.CardEffect.Damage;
    }

    public int GetAmount()
    {
        return Damage;
    }
}
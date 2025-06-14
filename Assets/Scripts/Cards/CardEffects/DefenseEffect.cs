using UnityEngine;

[System.Serializable]
public class DefenseEffect : ICardEffect
{
    public int Defense;
    public void Play()
    {
        if (!TurnManager.PlayerTurn)
            EnnemyArmy.Instance.AddDefense(Defense);

        else
            AllyArmy.Instance.AddDefense(Defense);
    }
    public void Buff(int amount)
    {
        Defense += amount;
    }
    public new ICardEffect.CardEffect GetType()
    {
        return ICardEffect.CardEffect.Defense;
    }

    public int GetAmount()
    {
        return Defense;
    }
}

using UnityEngine;

[System.Serializable]
public class DamageEffect : ICardEffect
{
    public int Damage;
    public enum Target {Player, Ennemy}
    public void Play()
    {
        if (TurnManager.PlayerTurn)
            EnnemyArmy.Instance.Hit(Damage);

        else
            AllyArmy.Instance.Hit(Damage);
    }
}
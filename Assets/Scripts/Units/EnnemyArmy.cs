using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemyArmy : Unit
{
    public static EnnemyArmy Instance;
    public EnemyData EnemyData;
    //L'ennemi ne peut qu'attaquer pour l'instant
    int minPower, maxPower;
    public TMP_Text NextActionText;
    DamageEffect damageEffect;
    DefenseEffect defenseEffect;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void InitArmy()
    {
        CPMax = EnemyData.CP;
        CP = CPMax;
        _cpText.text = $"CP : {CP} / {CPMax}";

        minPower = EnemyData.MinPower;
        maxPower = EnemyData.MaxPower;

        player = false;
        damageEffect = new();
        defenseEffect = new();
    }


    public void Play()
    {
        damageEffect.Play();
        defenseEffect.Play();
    }

    public void ShowNextAction()
    {
        int i = Random.Range(minPower, maxPower + 1);
        int n = Random.Range(0, i);
        damageEffect.Damage = n;
        defenseEffect.Defense = i - n;
        NextActionText.text = "Next action :\n" + damageEffect.Damage.ToString() + " Damage and " + defenseEffect.Defense.ToString() + " Defense";
    }

}

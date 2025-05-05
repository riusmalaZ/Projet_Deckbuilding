using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemyArmy : Unit
{
    public static EnnemyArmy Instance;
    //L'ennemi ne peut qu'attaquer pour l'instant
    public List<DamageEffect> PossibleActions;
    public DamageEffect NextAction;
    public TMP_Text NextActionText;
    
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        CP = CPMax;
        _cpText.text = $"CP : {CP} / {CPMax}";
        player = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNextAction()
    {
        DamageEffect nextEffect = PossibleActions[Random.Range(0, PossibleActions.Count)];
        NextAction = nextEffect;
        NextActionText.text = "Next action :\n" + nextEffect.Damage.ToString() + " Damage";
    }

}

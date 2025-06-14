using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int CPMax, CP, Defense;
    [SerializeField] internal TMP_Text _cpText;
    internal GameObject EndScreen;
    public Image HPBar;
    internal bool player;
    public TMP_Text DefenseText;

    void Start()
    {
        EndScreen = PauseScreen.Instance.PauseCanvas;
        Defense = 0;
    }

    public void Hit(int amount)
    {
        if (Defense > amount)
        {
            Defense -= amount;
            amount = 0;
        }
        else
        {
            amount -= Defense;
            Defense = 0;
        }

        DefenseText.text = Defense.ToString();
        CP -= amount;
        HPBar.fillAmount = (float)CP / CPMax;
        _cpText.text = $"CP : {CP} / {CPMax}";

        if (CP <= 0)
        {
            EndGame();
        }

        if (player)
        {
            AllyArmy.Instance.playerData.CP = CP;
        }
        
    }
    public void AddDefense(int amount)
    {
        Defense += amount;
        DefenseText.text = Defense.ToString();
    }

    public void EndGame()
    {
        PauseScreen.Instance.EndGame(!player);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int CPMax;
    public int CP;
    [SerializeField] internal TMP_Text _cpText;
    internal GameObject EndScreen;
    public Image HPBar;
    internal bool player;

    void Start()
    {
        EndScreen = PauseScreen.Instance.gameObject;
    }

    public void Hit(int amount)
    {
        CP -= amount;
        HPBar.fillAmount = (float)CP / CPMax;
        _cpText.text = $"CP : {CP} / {CPMax}";
        if (CP < 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        PauseScreen.Instance.EndGame(!player);
    }
}

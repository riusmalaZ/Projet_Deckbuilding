using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllyArmy : Unit
{
    public PlayerData playerData;
    [HideInInspector] public int APMax, AP;
    public TMP_Text APText;
    public static AllyArmy Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        APMax = playerData.MaxAP;
        AP = APMax;
        UpdateAPTxt();

        CPMax = playerData.ClassSelected.BaseCP;

        player = true;
        if (playerData.CP == 0)
        {
            playerData.CP = playerData.ClassSelected.BaseCP;

        }
        CP = playerData.CP;
        _cpText.text = $"CP : {CP} / {CPMax}";
        HPBar.fillAmount = (float)CP / CPMax;
    }

    public bool TryUseCard(int amount)
    {
        if (amount > AP)
        {
            print("La carte coute trop cher");
            return false;
        }
        else
        {
            return true;
        }
    }
    public void UseCard(int amount)
    {
        AP -= amount;
        UpdateAPTxt();
    }
    public void UpdateAPTxt()
    {
        if (APText != null )APText.text = $"Action Points :\n{AP}";
    }
}

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
    
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        APMax = playerData.MaxAP;
        AP = APMax;
        UpdateAPTxt();

        CPMax = playerData.CP;
        CP = CPMax;
        _cpText.text = $"CP : {CP} / {CPMax}";

        player = true;
    }

    public bool UseCard(int amount)
    {
        if (amount > AP)
        {
            print("La carte coute trop cher");
            return false;
        }
        else
        {
            AP -= amount;
            UpdateAPTxt();
            return true;
        }
    }
    public void UpdateAPTxt()
    {
        APText.text = $"Action Points :\n{AP}";
    }
}

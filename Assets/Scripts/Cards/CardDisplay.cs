using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class CardDisplay : MonoBehaviour
{
    public Card CardData;
    public Image CardImage;
    public TMP_Text NameText;
    public TMP_Text Description;
    public TMP_Text CostText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        NameText.text = CardData.CardName;
        NameText.color = Color.white;
        CardImage.sprite = CardData.CardSprite;
        Description.text = CardData.CardDescription;
        Description.color = Color.white;
        CostText.text = CardData.APCost.ToString();
        CostText.color = Color.white;
    }
}

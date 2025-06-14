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
    public GameObject Damage;
    public GameObject Defense;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        foreach (var effect in CardData.Effects)
        {
            if (effect.GetType() == ICardEffect.CardEffect.Damage)
            {
                Damage.SetActive(true);
                Damage.GetComponentInChildren<TMP_Text>().text = effect.GetAmount().ToString();
            }
            else if (effect.GetType() == ICardEffect.CardEffect.Defense)
            {
                Defense.SetActive(true);
                Defense.GetComponentInChildren<TMP_Text>().text = effect.GetAmount().ToString();
            }
        }

        NameText.text = CardData.CardName;
        NameText.color = Color.white;
        CardImage.sprite = CardData.CardSprite;
        Description.text = CardData.CardDescription;
        Description.color = Color.white;

        int modifiedCost = CardData.APCost;

        CostText.text = modifiedCost.ToString();
        CostText.color = Color.white;
    }


}

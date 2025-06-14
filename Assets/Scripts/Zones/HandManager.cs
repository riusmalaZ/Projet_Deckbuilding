using System.Collections.Generic;
using UnityEngine;

public class HandManager : CardList
{
    [SerializeField] PickZone _pickZone;
    [SerializeField] GameObject _cardPrefab;
    [Header("---Visual---")]
    public Transform HandTransform;
    public float FanSpread = 7.5f;
    public float HorizontalSpacing = 150f;
    public float VerticalSpacing = 100f;

    public void AddCardsToHand(int amount)
    {
        Add(Zones.Instance.Pick.Draw(amount).ToArray());

        foreach (GameObject cardObj in Cards)
        {
            cardObj.SetActive(true);
            RectTransform tfm = cardObj.GetComponent<RectTransform>();
            tfm.SetParent(transform);
            tfm.position = Vector3.zero;

            // Appliquer les buffs
            CardDisplay display = cardObj.GetComponent<CardDisplay>();
            if (display != null)
            {
                display.UpdateCardDisplay(); // Cette fonction affiche le coût modifié avec le buff
            }

        }

        UpdateHandVisuals();
    }

    public void UpdateHandVisuals()
    {
        int cardCount = Cards.Count;

        if (cardCount == 1)
        {
            Cards[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            Cards[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;
        }

        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (FanSpread * (i - (cardCount - 1) / 2f));
            Cards[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float horizontalOffset = HorizontalSpacing * (i - (cardCount - 1) / 2f);
            float normalizedPosition = 2f * i / (cardCount - 1) - 1f;
            float verticalOffset = VerticalSpacing * (1 - normalizedPosition * normalizedPosition);

            Cards[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }
}

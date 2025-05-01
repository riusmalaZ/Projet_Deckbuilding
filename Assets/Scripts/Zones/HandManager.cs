using System;
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
    public static List<GameObject> CardsInHand = new();

    void Start()
    {
        
    }

    public void AddCardsToHand(int amount)
    {
        List<GameObject> CardsToAdd = new ();
        if (amount > PickZone.CardsInPick.Count)
        {
            CardsToAdd = Draw(PickZone.CardsInPick.Count, PickZone.CardsInPick);
            _pickZone.ResetPick();
            CardsToAdd = Draw(amount - CardsToAdd.Count, PickZone.CardsInPick);
        }
        else 
            CardsToAdd = Draw(amount, PickZone.CardsInPick);
        
        foreach (GameObject card in CardsToAdd)
        {
            card.SetActive(true);
            RectTransform Tfm = card.GetComponent<RectTransform>();
            Tfm.SetParent(transform);
            Tfm.position = Vector3.zero;
            CardsInHand.Add(card);
        }

        UpdateHandVisuals();
    }


    //Fonction qui sert à placer les cartes en éventail
    public void UpdateHandVisuals()
    {
        
        int cardCount = CardsInHand.Count;

        if (cardCount == 1)
        {
            CardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            CardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;
        }

        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (FanSpread * (i - (cardCount - 1) / 2f));
            CardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float horizontalOffset = HorizontalSpacing * (i - (cardCount - 1) / 2f);

            float normalizedPosition = 2f * i / (cardCount - 1) - 1f; //normaliser la position des cartes entre -1 et 1
            float verticalOffset = VerticalSpacing * (1 - normalizedPosition * normalizedPosition);

            //Set la position des cartes
            CardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
        
    }

}

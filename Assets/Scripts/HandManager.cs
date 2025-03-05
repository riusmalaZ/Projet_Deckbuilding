using System;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject CardPrefab;
    public Transform HandTransform;
    public float FanSpread = 7.5f;
    public float HorizontalSpacing = 150f;
    public float VerticalSpacing = 100f;
    public List<GameObject> CardsInHand = new();

    void Start()
    {
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
    }

    public void AddCardToHand()
    {
        GameObject newCard = Instantiate(CardPrefab, HandTransform.position, Quaternion.identity, HandTransform);

        CardsInHand.Add(newCard);
        UpdateHandVisuals();
    }

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

            float horizontalOffset = (HorizontalSpacing * (i - (cardCount - 1) / 2f));

            float normalizedPosition = (2f * i / (cardCount - 1) - 1f); //normaliser la position des cartes entre -1 et 1
            float verticalOffset = VerticalSpacing * (1 - normalizedPosition * normalizedPosition);

            //Set la position des cartes
            CardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateHandVisuals();
    }
}

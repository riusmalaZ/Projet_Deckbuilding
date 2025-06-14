using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class CardsHandling : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    Vector3 initialPosition;
    [HideInInspector] public bool playable;
    HandManager hand;


    void Start()
    {
        initialPosition = transform.position;
        hand = GetComponentInParent<HandManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        int cardAP = GetComponent<CardDisplay>().CardData.APCost;
        playable = AllyArmy.Instance.TryUseCard(cardAP);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;


        if (!playable)
        {
            transform.position = initialPosition;
            return;
        }
       
        if (hand != null) hand.UpdateHandVisuals();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void Discard(Transform discardZone)
    {
        Zones.Instance.Hand.Cards.Remove(gameObject);
        Zones.Instance.Discard.Add(gameObject);
        transform.position = discardZone.position;
        transform.rotation = Quaternion.identity;
        transform.SetParent(discardZone);
    }
}

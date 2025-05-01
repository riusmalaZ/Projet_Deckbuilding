using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class CardsHandling : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    Vector3 initialPosition;
    [HideInInspector] public bool played;
    HandManager hand;

    void Start()
    {
        played = false;
        initialPosition = transform.position;
        hand =  GetComponentInParent<HandManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!played) transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (!played) transform.position = initialPosition;
        
        else 
        {
            foreach (ICardEffect effect in GetComponent<CardDisplay>().CardData.Effects)
            {
                effect.Play();
            }
            //Action de la carte
            hand.UpdateHandVisuals();
            //Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    internal void Discard(Transform discardZone)
    {
        HandManager.CardsInHand.Remove(gameObject);
        DiscardZone.DiscardedCards.Add(gameObject);
        transform.position = discardZone.position;
        transform.rotation = Quaternion.identity;
        transform.SetParent(discardZone);
    }
}

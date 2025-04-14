using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardsHandling : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    Vector3 initialPosition;
    [HideInInspector] public bool played;

    void Start()
    {
        played = false;
        initialPosition = transform.position;
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
        HandManager hand =  GetComponentInParent<HandManager>();
        if (!played) transform.position = initialPosition;
        
        else 
        {
            foreach (ICardEffect effect in GetComponent<CardDisplay>().CardData.Effects)
            {
                effect.Play();
            }
            //Action de la carte
            hand.CardsInHand.Remove(gameObject);
            hand.UpdateHandVisuals();
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
}

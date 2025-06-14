using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] Transform discardZone;

    public void OnDrop(PointerEventData eventData)
    {
        CardsHandling card = eventData.pointerDrag.GetComponent<CardsHandling>();

        if (card != null && card.playable)
        {
            card.Discard(discardZone);
            Card cardData = card.GetComponent<CardDisplay>().CardData;
            //Actions de la carte
            foreach (ICardEffect effect in cardData.Effects)
            {
                effect.Play();
            }
            int cardAP = card.GetComponent<CardDisplay>().CardData.APCost;
            AllyArmy.Instance.UseCard(cardAP);
            if (cardData.cardType != Card.CardType.Buff)
                TurnManager.Instance.DebuffHand();
            if (AllyArmy.Instance.Defense < 0) AllyArmy.Instance.AddDefense(-AllyArmy.Instance.Defense);
        }
    }
}
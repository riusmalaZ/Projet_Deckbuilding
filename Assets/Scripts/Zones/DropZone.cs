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
        }
    }
}
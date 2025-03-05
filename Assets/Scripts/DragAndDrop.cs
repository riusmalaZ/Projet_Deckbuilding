using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
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
            //Action de la carte
            GetComponentInParent<HandManager>().CardsInHand.Remove(gameObject);
            GetComponentInParent<HandManager>().UpdateHandVisuals();
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("ouais");
    }
}

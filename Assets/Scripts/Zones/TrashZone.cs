using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TrashZone : MonoBehaviour, IDropHandler
{
    [SerializeField] PlayerData _playerData;

    public void OnDrop(PointerEventData eventData)
    {
        CardsHandling card = eventData.pointerDrag.GetComponent<CardsHandling>();
        _playerData.ActualDeck.Remove(card.GetComponent<CardDisplay>()?.CardData);
        SceneManager.LoadScene("Navigation");
    }
}
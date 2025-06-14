using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardPick : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] List<Card> _allCards;
    [SerializeField] GameObject _card1, _card2, _card3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Card> copy = new(_allCards);
        for (int i = 0; i < copy.Count; i++)
        {
            int j = Random.Range(i, copy.Count);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }

        _card1.GetComponent<CardDisplay>().CardData = copy[0];
        _card1.GetComponent<CardDisplay>().UpdateCardDisplay();
        _card2.GetComponent<CardDisplay>().CardData = copy[1];
        _card2.GetComponent<CardDisplay>().UpdateCardDisplay();
        _card3.GetComponent<CardDisplay>().CardData = copy[2];
        _card3.GetComponent<CardDisplay>().UpdateCardDisplay();
    }

    public void PickButton(int i)
    {
        if (i == 1)
            _playerData.ActualDeck.Add(_card1.GetComponent<CardDisplay>().CardData);
        else if (i == 2)
            _playerData.ActualDeck.Add(_card2.GetComponent<CardDisplay>().CardData);
        else if (i == 3)
            _playerData.ActualDeck.Add(_card3.GetComponent<CardDisplay>().CardData);
        else
            _playerData.CP += 10;
        SceneManager.LoadScene("Navigation");
    }
}

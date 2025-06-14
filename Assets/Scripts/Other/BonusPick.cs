using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BonusPick : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] TMP_Text _bonus1, _bonus2, _bonus3;
    int r1, r2, r3;
    [SerializeField] GameObject _deck, _cardPrefab;
    GameObject _scrollView;
    public EventSystem EventSystem;
    public GraphicRaycaster Raycaster;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCards();
        _scrollView = _deck.GetComponentInParent<ScrollRect>().gameObject;
        _scrollView.SetActive(false);
        r1 = Random.Range(4, 9);
        r2 = Random.Range(6, 12);
        r3 = Random.Range(9, 15);
        if (r1 > _playerData.CP)
            r1 = _playerData.CP - 1;
        if (r2 > _playerData.CP)
            r2 = _playerData.CP - 1;
        if (r3 > _playerData.CP)
            r3 = _playerData.CP - 1;

        _bonus1.text = $"Open a Treasure. Lose {r1} CP.";
        _bonus2.text = $"Remove a card from your deck. Lose {r2} CP.";
        _bonus3.text = $"Gain 1 AP max for your next fight. Lose {r3} CP.";
    }


    public void PickButton(int i)
    {
        if (i == 1)
        {
            _playerData.CP -= r1;
            SceneManager.LoadScene("Treasure");
        }
        else if (i == 2)
        {
            _scrollView.SetActive(true);
            _playerData.CP -= r2;
        }

        else if (i == 3)
        {
            _playerData.CP -= r3;
            _playerData.APBoostActive = true;
            SceneManager.LoadScene("Navigation");
        }

        else
        {
            _playerData.CP += 8;
            SceneManager.LoadScene("Navigation");
        }
    }

    private void SpawnCards()
    {

        for (int i = 0; i < _playerData.ActualDeck.Count; i++)
        {
            GameObject cardInst = Instantiate(_cardPrefab);
            cardInst.transform.SetParent(_deck.transform);
            if (i < _playerData.ActualDeck.Count / 2)
            {
                cardInst.GetComponent<RectTransform>().anchoredPosition = new Vector2(200 + 300 * i, 700);
                cardInst.GetComponent<RectTransform>().localScale = new Vector3(100, 100, 100);
            }
            else
            {
                cardInst.GetComponent<RectTransform>().anchoredPosition = new Vector2(200 + 300 * (i - _playerData.ActualDeck.Count / 2), 300);
                cardInst.GetComponent<RectTransform>().localScale = new Vector3(100, 100, 100);
            }
            cardInst.GetComponent<CardDisplay>().CardData = _playerData.ActualDeck[i];
            cardInst.GetComponent<CardDisplay>().UpdateCardDisplay();


        }
    }
}

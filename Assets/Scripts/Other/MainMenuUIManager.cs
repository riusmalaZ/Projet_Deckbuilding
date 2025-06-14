using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject mainWindow;
    [SerializeField] GameObject classWindow;

    void Start()
    {
        GraphHolder.Instance.CurrentGraph = null;
        GraphHolder.Instance.CurrentNode = null;
        GraphHolder.Instance.PlayerPosition = Vector2.zero;
        playerData.CP = 0;
        playerData.ActualDeck = new();
        playerData.APBoostActive = false;
        playerData.ClassSelected = null;
        playerData.MaxAP = 0;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        classWindow.SetActive(true);
    }

    public void ClassButton(Class classSelected)
    {
        playerData.ClassSelected = classSelected;
        playerData.ActualDeck = classSelected.BaseDeck;
        playerData.MaxAP = classSelected.BaseAP;
        SceneManager.LoadScene("Fight");
    }
}

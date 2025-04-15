using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject mainWindow;
    [SerializeField] GameObject classWindow;
    
    void Start()
    {

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
    }
}

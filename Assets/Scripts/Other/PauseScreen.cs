using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static PauseScreen Instance;
    public GameObject PauseCanvas, ContinueButton, MainMenuButton;
    public TMP_Text ResultatText;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        ContinueButton.SetActive(false);
        MainMenuButton.SetActive(true);
        PauseCanvas.SetActive(false);
        if (ResultatText != null) ResultatText.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseCanvas.SetActive(!PauseCanvas.activeInHierarchy);
    }

    public void EndGame(bool won)
    {
        TurnManager.Instance.DebuffHand();
        PauseCanvas.SetActive(true);
        if (won)
        {
            if (GraphHolder.Instance.PlayerPosition.x != 15)
            {
                ResultatText.text = "Gagné";
                ResultatText.color = Color.green;
                ContinueButton.SetActive(true);
                MainMenuButton.SetActive(false);
            }
            else
            {
                ResultatText.text = "Roi du monde.";
                ResultatText.color = Color.green;
            }
        }
        else
        {
            ResultatText.text = "Perdu";
            ResultatText.color = Color.red;
        }

    }

    public void QuitButton()
    { Application.Quit(); }

    public void ReloadScene()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public void LoadScene(string sceneName)
    { SceneManager.LoadScene(sceneName); }

}

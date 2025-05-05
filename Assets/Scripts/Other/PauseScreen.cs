using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static PauseScreen Instance;
    public GameObject PauseCanvas;  
    public TMP_Text ResultatText;
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        PauseCanvas.SetActive(false);
        ResultatText.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            PauseCanvas.SetActive(!PauseCanvas.activeInHierarchy);
    }

    public void EndGame(bool won)
    {
        PauseCanvas.SetActive(true);
        if (won)
        {
            ResultatText.text = "Gagné";
            ResultatText.color = Color.green;
        }
        else
        {
            ResultatText.text = "Perdu";
            ResultatText.color = Color.red;
        }
        
    }

    public void QuitButton()
    {Application.Quit();}

    public void ReloadScene()
    {SceneManager.LoadScene(SceneManager.GetActiveScene().name);}

}

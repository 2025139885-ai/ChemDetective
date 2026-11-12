using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OpenStartInvestigation()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartInvestigation");
    }
    public void ExitGame()
    {
        Debug.Log("Exiting ChemDetective...");
        Application.Quit();
    }
}

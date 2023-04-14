using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMainMenu : MonoBehaviour
{
    public void OnStartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

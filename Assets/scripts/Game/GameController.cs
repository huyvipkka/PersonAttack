using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void ExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }
}
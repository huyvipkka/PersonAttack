using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private readonly float countdownTime = 5f;
    public GameObject uiTutorial;
    public GameObject pausemenu;
    private bool isPaused = false;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdownTime);
        uiTutorial.SetActive(false);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0; 
        isPaused = true;
        pausemenu.SetActive(true);
        Debug.Log("Game is paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausemenu.SetActive(false);
        Debug.Log("Game is resumed");
    }


}

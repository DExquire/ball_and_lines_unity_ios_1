using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Pause menu elements")]
    public GameObject pauseUIMenu;
    

    [Header("Pause menu logic")]
    public Button pauseBtn;
    private bool isPaused = false;

    private void Start()
    {
        pauseBtn.onClick.AddListener(SwitchPauseState);
        pauseUIMenu.SetActive(false); 
    }

    private void SwitchPauseState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; 
            pauseUIMenu.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1f; 
            pauseUIMenu.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseUIMenu.SetActive(false); 
    }

    public void InfoScreen()
    {
        SceneManager.LoadScene("InfoMenu");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DifficultMenu");
    }

}
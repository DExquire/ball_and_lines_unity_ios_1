using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    [Header("Pause menu elements")]
    public GameObject pauseScreen;

    [Header("Pause menu logic")]
    public bool alloudInput = false;
    public bool setPause;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (setPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SwitchInputOn()
    {
        alloudInput = true;
    }
    
    public void SwitchInputOff()
    {
        alloudInput = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        setPause = false;
        pauseScreen.SetActive(setPause);

    }

    public void Pause()
    {
        Time.timeScale = 0;
        setPause = true;
        pauseScreen.SetActive(setPause);
    }

    public void ReloadCurScene()
    {
        // ???????? ??? ??????? ?????
        string curScene = SceneManager.GetActiveScene().name;

        // ????????????? ??????? ?????
        SceneManager.LoadScene(curScene);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

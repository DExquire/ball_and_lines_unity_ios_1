using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerMini : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject gameScreen;
    public GameObject gameWinScreen;
    public GameObject gameOverScreen;
    public GameObject gameButtons;
    public float minDiff;
    public Button playButton;
    public int scoreNum;
    public List<Text> scoreTxt;
    public bool isFailed;

    public BallBehavior player;
    public CoilBehavior sample;
    
    void Start()
    {
        Time.timeScale = 1;
    }

   
    void Update()
    {
       /*if(Input.GetMouseButtonDown(0)) //&& gameScreen.activeSelf)
        {
            player.isTapped = true;
            

        }*/

        if (player.isTapped)
        {
            sample.MoveToTarget();
            sample.CheckIfWin();
        }
    }

    public void TouchScreen()
    {
//        if (gameScreen.activeSelf)
        {
            player.isTapped = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameButtons.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameButtons.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel"));
    }
}

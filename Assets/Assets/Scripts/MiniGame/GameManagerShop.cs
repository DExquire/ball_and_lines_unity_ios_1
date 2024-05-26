using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerShop : MonoBehaviour
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

    public BallBehaviour player;
    public CoilBehaviour sample;
    
    void OnEnable()
    {
    //    menuScreen.SetActive(true);
        playButton.onClick.AddListener(StartGame);
        gameButtons.SetActive(true);
        Time.timeScale = 1;
    }

   
    void Update()
    {
       /*if(Input.GetMouseButtonDown(0) && gameScreen.activeSelf)
        {
            player.isTapped = true;
            

        }*/
     /*   if (player.isTapped)
        {
            sample.MoveToTarget();
            sample.CheckIfWin();
        }*/

        if(isFailed)
        {
            Invoke("GameLose", 2);
            //GameLose();
        }
    }

    public void StartGame()
    {
        scoreNum = 0;
  /*      foreach(Text score in scoreTxt)
        {
            score.text = scoreNum.ToString();
        }*/
        menuScreen.SetActive(false);
        gameScreen.SetActive(true);
        gameButtons.SetActive(true);
    }

    public void TouchScreen()
    {
        if (gameScreen.activeSelf)
        {
         //   player.isTapped = true;
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

    public void GameWin()
    {
        gameButtons.SetActive(false);
        gameScreen.SetActive(false);
        gameWinScreen.SetActive(true);
        Invoke("LoadMenu", 3);
    }

    public void GameLose()
    {
        gameButtons.SetActive(false);
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        Invoke("LoadMenu", 3);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SavannaMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace grandpa
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;
        public Game shop;
        public GameObject menuScreen;
        public GameObject gameScreen;
        public GameObject gameWinScreen;
        public GameObject gameOverScreen;
        public GameObject gameButtons;
        public Button playButton;
        public Button soundButton;
        public int scoreNum;
        public List<Text> scoreTxt;
        public List<GameObject> columns;
        public bool isSoundOn;
        public AudioSource audioSource;
        public AudioSource woodAudioSource;
        public AudioSource playerAudioSource;
        public bool isGameOver;
        public float timer;
        public int highScore;
        public List<Text> timerTxt;
        public List<Text> highScoreTxt;
        public int dailyRew;
        public int lastDailyRew;
        public GameObject dailyRewardScreen;
        public int currentCoins;
        public Score scoreSrc;

        void Start()
        {
            gameManager = this;
            foreach (GameObject column in columns)
            {
                column.SetActive(false);
            }
            scoreNum = 0;
            foreach (Text scoreTxt in GameManager.gameManager.scoreTxt)
            {
                scoreTxt.text = scoreNum.ToString();
            }
            if (scoreTxt.Count > 0)
            {
                foreach (Text score in scoreTxt)
                {
                    score.text = scoreNum.ToString();
                }
            }
            //   menuScreen.SetActive(true);
            //   gameScreen.SetActive(false);
            //   gameButtons.SetActive(false);
            //   playButton.onClick.AddListener(StartGame);
            playButton.onClick.AddListener(LoadGame);
            //    ShowDailyRewardScreen();
            currentCoins = PlayerPrefs.GetInt("coins");

        }


        void Update()
        {
            if (!isGameOver)// && gameScreen.activeSelf)
            {
                timer += (Time.deltaTime);
                //            scoreSrc.timer = Mathf.FloorToInt(timer);
                foreach (Text timeText in timerTxt)
                {
                    timeText.text = Mathf.FloorToInt(timer).ToString();

                }

                //   if (PlayerPrefs.GetInt("highScore") < timer){PlayerPrefs.SetInt("highScore", Mathf.FloorToInt(timer));foreach (Text highScoreText in highScoreTxt){highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();}

                ChangeScore();

            }

            if (isGameOver)
            {
                scoreSrc.highScore = highScore;
                foreach (Text highscore in highScoreTxt)
                {
                    highScore = PlayerPrefs.GetInt("highScore");
                    //   highscore.text = highScore.ToString();
                }
            }
        }

        public void StartGame()
        {
            scoreNum = 0;
            foreach (Text score in scoreTxt)
            {
                score.text = scoreNum.ToString();
            }
            Time.timeScale = 1;
            menuScreen.SetActive(false);
            foreach (GameObject column in columns)
            {
                column.SetActive(true);
            }
            //        gameScreen.SetActive(true);
            //        gameButtons.SetActive(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void ChangeScore()
        {
            //int score = PlayerPrefs.GetInt("coins") + 1;
            //PlayerPrefs.SetInt("coins", score);

            //scoreNum += 1;
            foreach (Text scoreT in scoreTxt)
            {
                scoreT.text = scoreSrc.scoreNum.ToString();
            }
        }

        public void SetSound()
        {
            if (audioSource.mute == false)
            {
                isSoundOn = true;

                audioSource.mute = true;
                playerAudioSource.mute = true;

                soundButton.transform.GetChild(0).gameObject.SetActive(true);
                soundButton.transform.GetChild(1).gameObject.SetActive(false);
            }

            else if (audioSource.mute == true)
            {
                isSoundOn = false;

                audioSource.mute = false;
                playerAudioSource.mute = false;

                soundButton.transform.GetChild(0).gameObject.SetActive(false);
                soundButton.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        public void GetDailyRew()
        {
            int currentCoins = PlayerPrefs.GetInt("coins");
            currentCoins += dailyRew;
            shop.Coins = currentCoins;

            PlayerPrefs.SetInt("coins", currentCoins);
            shop.UpdateAllCoinsUIText();

            dailyRewardScreen.SetActive(false);
            PlayerPrefs.SetInt("LastRewDay", lastDailyRew);
        }

        public void ShowDailyRewardScreen()
        {
            lastDailyRew = System.DateTime.Now.Day;
            if (lastDailyRew != PlayerPrefs.GetInt("LastRewDay"))
            {
                dailyRewardScreen.SetActive(true);
            }
        }


        public void GameWin()
        {
            gameScreen.SetActive(false);
            gameWinScreen.SetActive(true);
            //   Invoke("LoadMenu", 3);
        }

        public void GameLose()
        {
            gameOverScreen.SetActive(true);
            //        gameScreen.SetActive(false);
            //   Invoke("LoadMenu", 3);
        }

        public void LoadMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("main");
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}

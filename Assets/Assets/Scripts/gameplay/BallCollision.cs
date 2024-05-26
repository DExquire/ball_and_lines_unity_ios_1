using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    public static BallCollision instance;
    private bool timerRunning = true; 
    private int highScore = 0;
    public int lives;

    public GameObject winGameScene;
    public GameObject loseGameScene;
    public GameObject startFalseBoomb;
    public GameObject startBombAnim;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public int timerValue = 60;

    private SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;

    public List<Sprite> ballSprite;
    public ReplayPanel replayPanel;

    public float startPos;
    public float finishPos;

    public PhysicsMaterial2D physicsMaterial;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
     //   highScore = PlayerPrefs.GetInt("HighScore", 0);
     //   scoreText.text = highScore.ToString();  

        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        //int buyValue = PlayerPrefs.GetInt("Buy", 0);
        int buyValue = PlayerPrefs.GetInt("skinIndex", 0);
        //Debug.Log("Skin" + buyValue);
        Debug.Log("skinIndex" + buyValue);

        switch (buyValue)
        {
            case 1:
                spriteRenderer.sprite = ballSprite[0];
                break;
            case 2:
                spriteRenderer.sprite = ballSprite[1];
                break;
            case 3:
                spriteRenderer.sprite = ballSprite[2];
                break;
            case 4:
                spriteRenderer.sprite = ballSprite[3];
                break;
            default:
                spriteRenderer.sprite = defaultSprite;
                break;
        }

        StartTimer();
    }

    private void Update()
    {
        if(transform.GetComponent<RectTransform>().anchoredPosition.y >= startPos)
        {
            //  GetComponent<CircleCollider2D>().isTrigger = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //   physicsMaterial.bounciness = 0.2f;
         /*   PhysicsMaterial2D newMaterial = new PhysicsMaterial2D("RandomlyBouncy");
            newMaterial.bounciness = 0.2f;

            GetComponent<Rigidbody2D>().sharedMaterial = newMaterial;*/
        }
        
    }

    void StartTimer()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timerValue > 0)
        {
            timerText.text = timerValue.ToString();
            yield return new WaitForSeconds(1f);
            timerValue--;
        }

        replayPanel.TryShowNetworkPanel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boomb" && timerRunning)
        {
            PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
            //print(PlayerPrefs.GetInt("lastLevel"));
            //timerRunning = false;
            //    collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //   startBombAnim.SetActive(true);
            //   StartCoroutine(ActivateGameOverMenuAfterDelay(2f));
            lives-=1;

            if(lives == 1)
            {
                loseGameScene.SetActive(true);
            //    StartCoroutine(ActivateGameOverMenuAfterDelay(2f));
            }
        }

        if (collision.gameObject.tag == "Cup" && timerRunning)
        {
            //Debug.Log("Object touched the Cup!");
            timerRunning = false;

            // ????????? ?????????? ????? ? HighScore
            highScore = PlayerPrefs.GetInt("HighScore");
            highScore += Mathf.FloorToInt(timerValue);

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            Debug.Log("HighScore: " + highScore);

            LaunchWinScene();
        //    LaunchRandomScene();
        }

        if(collision.gameObject.tag == "Floor")
        {
        /*    GetComponent<Rigidbody2D>().AddForce(Vector2.up*8.2f, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;*/

        }
    }

    private IEnumerator ActivateGameOverMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        replayPanel.TryShowNetworkPanel();
    }

    void LaunchWinScene()
    {
        winGameScene.SetActive(true);
    }

    public void LaunchRandomScene()
    {
        int randomLevelInt = Random.Range(1, 6);
        string sceneName = "SavannaLevel"+ randomLevelInt;
        SceneManager.LoadScene(sceneName);
    }

    public void StartMiniGame()
    {
        SceneManager.LoadScene("miniGame");
    }

    /*void LoadNextScene()
    {
        SceneManager.LoadScene("DifficultMenu"); 
    }*/
}
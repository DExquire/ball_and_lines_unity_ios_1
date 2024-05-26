using UnityEngine;

public class CoilBehavior : MonoBehaviour
{
    public GameManagerMini gameManager;
    public GameObject ball;
    public Transform endPoint;
    public float speed;
    public GameObject winScreen;
    public bool isFailed;


    public void MoveToTarget()
    {
        if(!isFailed)
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
    }

    public void CheckIfWin()
    {
        if(!isFailed && transform.position == endPoint.position)
        {
            Invoke("GameWin", 2);
        }

        else if(isFailed)
        {
            Invoke("GameLose", 2);
        }
    }

    public void GameWin()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
            gameManager.gameScreen.SetActive(false);
            gameManager.gameButtons.SetActive(false);
        }
    }

    public void GameLose()
    {
        if (gameManager.gameOverScreen != null)
        {
            gameManager.gameOverScreen.SetActive(true);
            gameManager.gameScreen.SetActive(false);
            gameManager.gameButtons.SetActive(false);
        }
    }
}

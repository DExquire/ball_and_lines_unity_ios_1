using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponentInParent<CoilBehaviour>().gameManager;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent.GetChild(1).gameObject.SetActive(true);
            //   gameManager.GameLose();
            if (gameManager.lives > 1)
            {
                gameManager.lives--;
                gameManager.livesText.text = gameManager.lives.ToString();
            }
            else
            {
                gameManager.GameLose();
            }
            foreach (GameObject column in gameManager.columns)
            {
//                column.SetActive(false);
            }
        }
    }
}

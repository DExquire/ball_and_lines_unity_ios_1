using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class CoilBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public float speed;
    public Joystick joystick;
    public float lowerLimit;
    public float upperLimit;
    public Transform limitPoint;

    void FixedUpdate()
    {
        if (transform.position.x <= limitPoint.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            //var yPos = Random.Range(lowerLimit, upperLimit); limitPoint.position = new Vector3(limitPoint.position.x, yPos, 0);
        }
        else
        {
            //   transform.position = Vector3.MoveTowards(transform.position, limitPoint.position, speed * Time.fixedDeltaTime);
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
        //    Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            gameManager.GameLose();
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class BallBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public Rigidbody2D rb;
    public Image spriteRenderer;
    public List<Sprite> skins;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Image>().sprite = skins[PlayerPrefs.GetInt("skinIndex")];
    }

    void Update()
    {
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
     //   rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        transform.position = new Vector2(//transform.position.x,
                                         Mathf.Clamp(joystick.Horizontal * Time.deltaTime * speed + transform.position.x, -10f, 10f),
           transform.position.y //Mathf.Clamp(joystick.Vertical * Time.deltaTime * speed + transform.position.y, -3.5f, 5.5f)
           );
    
    //    if(Input.GetMouseButtonDown(0)){rb.velocity = Vector2.up * speed;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pearl"))
        {
            GameManager.gameManager.scoreNum += 1;
            GameManager.gameManager.ChangeScore();
            collision.gameObject.SetActive(false);
        }

        else if(collision.CompareTag("Wall"))
        {
            GameManager.gameManager.GameLose();
        }
    }
}*/

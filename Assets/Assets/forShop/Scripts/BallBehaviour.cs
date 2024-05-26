using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public Rigidbody2D rb;
    public List<GameObject> charSkins;
    
 //   public Game shop;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(transform.GetChild(0).gameObject);
        Instantiate(charSkins[PlayerPrefs.GetInt("skinIndex")], transform);
    }

    void Update()
    {
     //   Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
     //   rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        transform.position = new Vector2(transform.position.x,//Mathf.Clamp(joystick.Horizontal * Time.deltaTime * speed + transform.position.x, -10f, 10f),
           Mathf.Clamp(joystick.Vertical * Time.deltaTime * speed + transform.position.y, -3.5f, 5.5f)
           );

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            int coins = PlayerPrefs.GetInt("coins");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().gameShop.Coins = coins + 5;
            //shop.Coins += coins;
            PlayerPrefs.SetInt("coins", GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().gameShop.Coins);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().coinsText.text = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().gameShop.Coins.ToString();
            Destroy(collision.gameObject);
        }
    }
}

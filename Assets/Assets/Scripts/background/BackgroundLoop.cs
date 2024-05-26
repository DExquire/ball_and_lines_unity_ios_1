using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject bG1;
    public GameObject bG2;
    public float bgMovingSpeed;
    public float bgMovingSpeed2;

    private SpriteRenderer imageBG1;
    private SpriteRenderer imageBG2;
    public List<Sprite> sprites; // List to store sprites

    void Start()
    {
//        imageBG1 = bG1.GetComponent<SpriteRenderer>();
//        imageBG2 = bG2.GetComponent<SpriteRenderer>();
        SetSprite();
    }



    void Update()
    {
        MovingBG();
        RestartPosition();
    }

    void SetSprite()
    {
        int randomBG = Random.Range(0, sprites.Count);

/*        imageBG1.sprite = sprites[randomBG];
        imageBG2.sprite = sprites[randomBG]; */
    }

    void MovingBG()
    {
        bgMovingSpeed2 = bgMovingSpeed;
        bG1.transform.Translate(Vector2.left * bgMovingSpeed * Time.deltaTime);
        bG2.transform.Translate(Vector2.left * bgMovingSpeed2 * Time.deltaTime);
    }

    void RestartPosition()
    {
        float backgroundWidth = imageBG1.bounds.size.x;

        if (bG1.transform.position.x <= -backgroundWidth)
        {
            bG1.transform.Translate(Vector2.right * backgroundWidth * 2);
        }

        if (bG2.transform.position.x <= -backgroundWidth)
        {
            bG2.transform.Translate(Vector2.right * backgroundWidth * 2);
        }
    }

    
}

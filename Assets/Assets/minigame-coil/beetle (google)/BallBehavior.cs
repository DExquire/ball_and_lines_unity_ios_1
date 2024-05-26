using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public GameManagerMini gameManager;

    public float speed;
    public int dir = 1;
    public bool isTapped;
    

    void Start()
    {
        dir = Random.Range(-1, 1);
        if(dir == 0)
        {
            dir = 1;
        }
        isTapped = false;
        speed = Random.Range(200, 400);
    }

    void Update()
    {
        if(!isTapped) //&& gameManager.gameScreen.activeSelf)
        RotatePlayer();
    }

    public void RotatePlayer()
    {
        transform.Rotate(Vector3.forward * dir * speed * Time.deltaTime);
    }
}

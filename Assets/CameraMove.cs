using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public RectTransform ballPosition;
    
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Debug.Log(ballPosition.position.y);
        if (transform.position.y - ballPosition.position.y > 0.5f && transform.position.y > -6.8f)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * 0;
        }
    }
}

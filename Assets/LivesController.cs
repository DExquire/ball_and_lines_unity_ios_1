using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject liveContainer;


    private void Update()
    {
        RemoveLife();
    }

    public void RemoveLife()
    {
        liveContainer.transform.GetChild(BallCollision.instance.lives + 1).GetChild(1).gameObject.SetActive(true);
    }
}

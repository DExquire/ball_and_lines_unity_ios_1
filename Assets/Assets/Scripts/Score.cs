using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int scoreNum;
    public int timer;
    public int highScore;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("highScore"));
    }
}

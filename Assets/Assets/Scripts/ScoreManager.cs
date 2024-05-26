using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void OnEnable()
    {
        SetScore();
    }

    public void SetScore()
    {
        print(PlayerPrefs.GetInt("HighScore"));
        score.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}

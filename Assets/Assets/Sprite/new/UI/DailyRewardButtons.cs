using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardButtons : MonoBehaviour
{
    public float activeState;
    public float inActiveState;
    public List<GameObject> rewardButtons;
    public int lastReward;
    public int curReward;
    public DateTime lastClaimTime;
    public GameObject dailyPanel;

    private void Start()
    {
        string lastTime = PlayerPrefs.GetString("LastClaimTime");
        curReward = PlayerPrefs.GetInt("dailyRew");

        if(!string.IsNullOrEmpty(lastTime))
        {
            Debug.Log(lastTime);
            lastClaimTime = DateTime.Parse(lastTime);
        }
        else
        {
            lastClaimTime = DateTime.Today;
        }

        if (DateTime.Today.Date > lastClaimTime.Date)
        {
            dailyPanel.SetActive(true);
        }
        else
        {
            if (curReward != 0)
            {
                dailyPanel.SetActive(false);
            }
            else
            {
                dailyPanel.SetActive(true);
                curReward = 1;
            }
        }

    //    CheckTimeForReward();
        SetInActive();
        SetActive();
    }

    public void CheckTimeForReward()
    {
        lastReward = PlayerPrefs.GetInt("dailyRew");
    }

    //save current bonus button
    public void SaveReward()
    {
        lastClaimTime = DateTime.Today;
        PlayerPrefs.SetString("LastClaimTime", lastClaimTime.ToString());

        PlayerPrefs.SetInt("dailyRew", curReward);
    }

    //disable all bonus buttons
    public void SetInActive()
    {
        foreach(GameObject but in rewardButtons)
        {
            but.GetComponent<Image>().color = new(1,1,1, inActiveState);
            but.GetComponent<Button>().interactable = false;
        }
    }

    //set current daily bonus button
    public void SetActive()
    {
        if (DateTime.Today > lastClaimTime)
        {
            curReward += 1;

            if (curReward == 8)
            {
                curReward = 0;
            }
        }
        rewardButtons[curReward-1].GetComponent<Image>().color = new(1, 1, 1, activeState);
        rewardButtons[curReward-1].GetComponent<Button>().interactable = true;

        PlayerPrefs.SetInt("dailyRew", curReward);

    }

    //Button event
    public void ButtonClicked()
    {
        rewardButtons[curReward-1].transform.GetChild(0).gameObject.SetActive(true);
        int score = PlayerPrefs.GetInt("HighScore") + 50;
        PlayerPrefs.SetInt("HighScore", score);
    }
}

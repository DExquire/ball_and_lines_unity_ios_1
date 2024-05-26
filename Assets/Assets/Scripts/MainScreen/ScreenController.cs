using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject infoScreen;
    public GameObject questionsScreen;
    public GameObject shopScreen;
    public GameObject soundScreen;

    public void SwitchInfoScreen(bool trig)
    {
        mainMenu.SetActive(!trig);
        infoScreen.SetActive(trig);
    }

    public void SwitchQuestionScreen(bool trig)
    {
        mainMenu.SetActive(!trig);
        infoScreen.SetActive(trig);
    }

    public void SwitchShopScreen(bool trig)
    {
        mainMenu.SetActive(!trig);
        shopScreen.SetActive(trig);
    }

    public void ToggleSound(bool trig)
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

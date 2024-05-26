using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel(int lvlNum)
    {
        SceneManager.LoadScene(lvlNum);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private void Start()
    {
        LoadMenuAfterTime();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("SavannaMenu");
    }

    public void LoadMenuAfterTime()
    {
        Invoke("LoadMenu", 3);
    }
}

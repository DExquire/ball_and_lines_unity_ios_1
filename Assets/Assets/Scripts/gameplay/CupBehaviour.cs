using UnityEngine;
using UnityEngine.SceneManagement;

public class CupBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cup")
        {
        //    Debug.Log("Object touched the Cup!");

        //    LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("New Scene");
    }
}

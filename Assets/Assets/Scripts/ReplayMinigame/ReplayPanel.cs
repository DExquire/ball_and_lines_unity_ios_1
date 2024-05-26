using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayPanel : MonoBehaviour
{
    public GameObject gameOverMenu;

    [Header("Settings")]
    private int probability = 25;

    [Header("Settings Menu")]
    public GameObject reloadMinigamePopup;

    public void TryShowNetworkPanel()
    {
        int randomValue = Random.Range(0, 100);

        // Проверяем, выполняется ли условие для вызова панели ReloadMiniGame
      //  if (randomValue < probability)
        {
            ShowNetworkPanel();
        }

     //   else
        {

        }
    }

    private void ShowNetworkPanel()
    {
        // Код для отображения панели ReloadMiniGame
        Debug.Log("Панель вызвана!");
        reloadMinigamePopup.SetActive(true);
    }

    private void ShowGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void CancelClosePanel()
    {
        reloadMinigamePopup.SetActive(false);
    }

    public void ApplyClosePanel()
    {
        reloadMinigamePopup.SetActive(false);
        SceneManager.LoadScene("Mini game");
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button retryButton;
    public Button mainMenuButton;

  //  private AdManager adManager;

    void Start()
    {
        gameOverPanel.SetActive(false);

        retryButton.onClick.AddListener(Retry);
        mainMenuButton.onClick.AddListener(GoToMainMenu);

        //adManager = FindAnyObjectByType<AdManager>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

      //  if (adManager != null)
         //   adManager.ShowInterstitial();
    }

    public void Retry() // <-- ahora es pública
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMainMenu() // <-- ahora es pública
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

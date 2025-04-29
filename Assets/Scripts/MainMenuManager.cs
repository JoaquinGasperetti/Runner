using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    void Start()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Asegurate que tu primer nivel esté en el índice 1
    }

    public void RateApp()
    {
        string appPackageName = "com.HKemtrentertainment.MessiSimulator";
        string url = $"https://play.google.com/store/apps/details?id=com.HKemtrentainment.MessiSimulator&hl=es_AR";

#if UNITY_ANDROID
        Application.OpenURL(url);
#else
        Debug.Log("Abrir calificación solo disponible en Android.");
#endif
    }
}

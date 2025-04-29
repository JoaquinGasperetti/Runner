using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesController : MonoBehaviour
{
    // Variable para saber si ya se ha intentado iniciar sesión
    private bool isAuthenticated = false;

    void Start()
    {
        // Configura e inicia la plataforma de Google Play Games
        PlayGamesPlatform.Activate();

        // Intenta iniciar sesión automáticamente cuando el juego se inicia
        SignIn();
    }

    // Método para iniciar sesión en Google Play Games
    public void SignIn()
    {
        if (isAuthenticated) return; // Evita reintentar el inicio de sesión si ya está autenticado

        // Inicia sesión de forma automática
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Inicio de sesión exitoso en Google Play Games.");
                isAuthenticated = true; // Marca que ya está autenticado
            }
            else
            {
                Debug.LogError("Error al iniciar sesión en Google Play Games.");
            }
        });
    }
}

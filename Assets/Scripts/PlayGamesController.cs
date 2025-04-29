using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesController : MonoBehaviour
{
    // Variable para saber si ya se ha intentado iniciar sesi�n
    private bool isAuthenticated = false;

    void Start()
    {
        // Configura e inicia la plataforma de Google Play Games
        PlayGamesPlatform.Activate();

        // Intenta iniciar sesi�n autom�ticamente cuando el juego se inicia
        SignIn();
    }

    // M�todo para iniciar sesi�n en Google Play Games
    public void SignIn()
    {
        if (isAuthenticated) return; // Evita reintentar el inicio de sesi�n si ya est� autenticado

        // Inicia sesi�n de forma autom�tica
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Inicio de sesi�n exitoso en Google Play Games.");
                isAuthenticated = true; // Marca que ya est� autenticado
            }
            else
            {
                Debug.LogError("Error al iniciar sesi�n en Google Play Games.");
            }
        });
    }
}

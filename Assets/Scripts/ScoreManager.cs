using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instancia;

    public int puntaje = 0;
    public TextMeshProUGUI textoPuntaje;

    private float tiempoTranscurrido = 0f; // Contador de tiempo

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Incrementamos el contador de tiempo
        tiempoTranscurrido += Time.deltaTime;

        // Sumamos puntos cada segundo
        if (tiempoTranscurrido >= 1f)
        {
            puntaje += 10; // 10 puntos por segundo
            tiempoTranscurrido = 0f; // Reseteamos el contador de tiempo
        }

        // Actualizamos el texto en pantalla
        textoPuntaje.text = "Puntos: " + puntaje.ToString();
        Debug.Log("Puntaje: " + puntaje);
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
    }
}

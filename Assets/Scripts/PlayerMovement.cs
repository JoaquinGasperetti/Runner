using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 3f; // Distancia entre carriles
    private int currentLane = 1; // 0 = izquierda, 1 = centro, 2 = derecha

    void Update()
    {
        // Movimiento hacia adelante
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Movimiento entre carriles
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
        }

        // Posición del carril
        Vector3 targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }
}

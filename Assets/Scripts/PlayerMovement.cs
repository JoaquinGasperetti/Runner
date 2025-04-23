using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;

    private int currentLane = 1;
    private Rigidbody rb;
    private Vector3 targetPosition;

    public GameOverManager gameOverManager;
    private bool canCollide = true;  // Bandera para controlar las colisiones

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!canCollide) return;  // Si no puede colisionar, no procesamos la l�gica

        Vector3 velocity = rb.linearVelocity;

        if (transform.position.y < -10f)
        {
            gameOverManager.GameOver();
            return;
        }

        velocity.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            velocity.y = jumpForce;
        }
        else
        {
            velocity.y = rb.linearVelocity.y;
        }

        rb.linearVelocity = velocity;

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * 10f);
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeLane(-1);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangeLane(1);
    }

    void ChangeLane(int direction)
    {
        int targetLane = Mathf.Clamp(currentLane + direction, 0, 2);
        if (targetLane != currentLane)
        {
            currentLane = targetLane;
            float targetX = (currentLane - 1) * laneDistance;
            targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            if (canCollide)
            {
                gameOverManager.GameOver();
            }
        }
    }

    public void DisableCollisions()
    {
        canCollide = false;  // Desactivar las colisiones
    }

    public void EnableCollisions()
    {
        canCollide = true;   // Activar las colisiones
    }
}

using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del obstáculo

    void Update()
    {
        // Movimiento del obstáculo hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Detener el movimiento si choca con el jugador
            speed = 0f;
        }
    }
}

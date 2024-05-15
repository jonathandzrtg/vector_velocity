using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del obst�culo

    void Update()
    {
        // Movimiento del obst�culo hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

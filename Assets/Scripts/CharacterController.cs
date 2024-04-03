using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para recargar la escena

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    public bool isJumping = false;
    public float rotationSpeed = 360f;
    public GameObject explosionPrefab; // Prefab del efecto de explosión

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (!isJumping)
        {
            transform.rotation = Quaternion.identity; // reset rotation when on ground    
        }
        else
        {
            RotateCharacter();
        }

        // Verificar si el personaje toca el borde izquierdo de la cámara
        if (transform.position.x <= Camera.main.ViewportToWorldPoint(Vector3.zero).x)
        {
            RestartGame();
        }
    }

    void RotateCharacter()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Destroy")
        {
            // Crear el efecto de explosión
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Reiniciar el juego
            RestartGame();
        }
        else if (col.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    void RestartGame()
    {
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Recargar la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }
}

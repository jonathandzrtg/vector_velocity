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
    public GameObject explosionPrefab; // Prefab del efecto de explosi�n

    private AudioSource audioSource;
    public AudioClip sonidoSalto;
    public AudioClip sonidoMoneda;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            audioSource.PlayOneShot(sonidoSalto);
        }

        if (!isJumping)
        {
            transform.rotation = Quaternion.identity; // reset rotation when on ground    
        }
        else
        {
            RotateCharacter();
        }

        // Verificar si el personaje toca el borde izquierdo de la c�mara
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
            // Crear el efecto de explosi�n
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Reiniciar el juego
            RestartGame();
        }
        else if (col.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
        else if (col.gameObject.tag == "Ganar") 
        {
             SceneManager.LoadScene("Final_Menu");
        }
    }

    void RestartGame()
    {
        // Obtener el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Recargar la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Verifica si el objeto con el que colision� tiene la etiqueta "Moneda"
        if (collider.CompareTag("Moneda"))
        {
            audioSource.PlayOneShot(sonidoMoneda);
            Destroy(collider.gameObject); // Destruye el objeto moneda
        }
    }

}

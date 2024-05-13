using UnityEngine;

public class movimiento_personaje : MonoBehaviour
{
    public float velocidad; 
    public float fuerzaSalto;
    private Rigidbody2D rb;
    private AudioSource audioSource;  
    public AudioClip sonidoSalto;     
    public AudioClip sonidoMoneda;    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarSalto();
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            audioSource.PlayOneShot(sonidoSalto);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "Moneda"
        if (collider.CompareTag("Moneda"))
        {
            audioSource.PlayOneShot(sonidoMoneda);
            Destroy(collider.gameObject); // Destruye el objeto moneda
        }
    }
}

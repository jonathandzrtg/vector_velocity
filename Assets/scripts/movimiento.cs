using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
  
    public float velocidadRotacion = 50.0f;

   
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
     void OnCollisionEnter2D(Collision2D collision)  
       {         // Verifica si la colisión es con el personaje
       if (collision.gameObject.CompareTag("Jugador"))        
        {             // Destruye este objeto            
        Destroy(gameObject);      
           }     }
}


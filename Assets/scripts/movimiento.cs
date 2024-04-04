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
}


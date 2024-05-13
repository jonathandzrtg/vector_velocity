using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidadRotacion = 50.0f; // Velocidad a la que rota la moneda

    void Update()
    {
        // Hace que la moneda rote continuamente alrededor de su eje vertical
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonActivable : MonoBehaviour
{
    private Renderer renderer;
    private bool activado = false;

    // Referencia al administrador del nivel (para saber cu�ntos botones se han activado)
    public AdministradorNivel adminNivel;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        CambiarColor(Color.red);  // Inicialmente el bot�n es rojo
    }

    void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Pelota"))
        {
            activado = true;
            CambiarColor(Color.green);  // Cambiar el color a verde cuando se active
            adminNivel.BotonActivado();  // Notificar al administrador del nivel que este bot�n ha sido activado
        }
    }

    void CambiarColor(Color color)
    {
        renderer.material.color = color;
    }
}
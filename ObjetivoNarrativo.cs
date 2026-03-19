using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjetivoNarrativo : MonoBehaviour
{
    // 1. Arrastra aquí el Panel UI
    public GameObject panelDeInformacion;

    // 2. VARIABLE NUEVA
    // Para evitar contar la misma pista varias veces
    private bool haSidoDescubierto = false;

    void OnMouseDown()
    {
        // 3. LÓGICA MODIFICADA
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (panelDeInformacion != null)
        {
            panelDeInformacion.SetActive(true);
        }

       
        if (!haSidoDescubierto)
        {
            haSidoDescubierto = true; // Lo marcamos como "descubierto"

            // ¡Y le avisamos al GameManager que encontramos una pista!
            GameManager.instance.RegistrarAcierto();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZoneTrap : MonoBehaviour
{
   public GameObject picos; // Arrastra el GameObject de los picos aqu� en el inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            Debug.Log("Pelota ha entrado en la zona de activaci�n de picos.");
            picos.GetComponent<Tramp_Slide>().EmergerPicos(); // Llama al m�todo en el script de picos
        }
    }
}

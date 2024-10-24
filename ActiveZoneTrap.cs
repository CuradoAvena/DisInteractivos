using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZoneTrap : MonoBehaviour
{
   public GameObject picos; // Arrastra el GameObject de los picos aquí en el inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelota"))
        {
            Debug.Log("Pelota ha entrado en la zona de activación de picos.");
            picos.GetComponent<Tramp_Slide>().EmergerPicos(); // Llama al método en el script de picos
        }
    }
}

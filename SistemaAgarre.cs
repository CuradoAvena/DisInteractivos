using UnityEngine;

public class SistemaAgarre : MonoBehaviour
{
    [Header("Ajustes")]
    public float distanciaAgarre = 3f; // Qué tan lejos alcanzan tus brazos
    public Transform posicionMano;     // El objeto vacío que creamos antes
    public LayerMask capaObjetos;      // (Opcional) Para filtrar qué tocamos

    private GameObject objetoEnMano = null; // Variable para saber si cargamos algo

    void Update()
    {
        // Al presionar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objetoEnMano == null)
            {
                // Si NO tengo nada -> Intento agarrar
                IntentarAgarrar();
            }
            else
            {
                // Si SI tengo algo -> Lo suelto
                SoltarObjeto();
            }
        }
    }

    void IntentarAgarrar()
    {
        RaycastHit hit;
        // Lanzamos rayo desde la cámara hacia adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaAgarre))
        {
            // ¿El objeto que miré tiene el tag "Agarrable"?
            if (hit.transform.CompareTag("Llave"))
            {
                Agarrar(hit.transform.gameObject);
            }
        }
    }

    void Agarrar(GameObject objeto)
    {
        objetoEnMano = objeto;

        // 1. Desactivar físicas (Para que no pese ni choque con nosotros)
        Rigidbody rb = objeto.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        // 2. Hacerlo HIJO de nuestra mano (Parenting)
        objeto.transform.SetParent(posicionMano);

        // 3. Resetear posición y rotación para que quede perfecto en la mano
        objeto.transform.localPosition = Vector3.zero;
        objeto.transform.localRotation = Quaternion.identity;
    }

    void SoltarObjeto()
    {
        // 1. Reactivar físicas (Para que caiga al suelo)
        Rigidbody rb = objetoEnMano.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            // Opcional: Lanzarlo un poco
            // rb.AddForce(transform.forward * 5f, ForceMode.Impulse); 
        }

        // 2. Quitarlo de hijo (Unparent)
        objetoEnMano.transform.SetParent(null);

        // 3. Vaciar la mano
        objetoEnMano = null;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ObjetoIncorrecto : MonoBehaviour
{
    [Header("Eventos")]
    [Tooltip("Conecta aquí los efectos visuales o sonidos a reproducir")]
    public UnityEvent alCometerError;

    private bool yaSeActivo = false;

    void OnMouseDown()
    {
        // 1. Validaciones
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (yaSeActivo) return;

        yaSeActivo = true;

        // 2. Lógica dura del juego
        Debug.Log("¡CLIC INCORRECTO detectado en " + gameObject.name + "!");
        GameManager.instance.RegistrarError();

        // 3. Disparar el evento (desacoplamiento)
        // Quien sea que esté escuchando, que haga su trabajo.
        alCometerError.Invoke();
    }
}

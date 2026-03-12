using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDiorama : MonoBehaviour
{
    // 1. Arrastra aquí tu "DIORAMA_PADRE" desde la Jerarquía
    public Transform targetDiorama;

    // 2. Sensibilidad (ajusta estos valores en el Inspector)
    public float rotateSpeed = 5.0f;
    public float zoomSpeed = 10.0f;

    // 3. Límites del Zoom (Field of View de la cámara)
    public float minFov = 20f;
    public float maxFov = 60f;

    // Guardaremos la cámara aquí para eficiencia
    private Camera cam;

    void Start()
    {
        // Obtiene el componente de Cámara de este objeto
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // -------- ROTACIÓN (CON CLIC DERECHO) --------

        
        if (Input.GetMouseButton(1)) 
        {
            // Obtiene el movimiento del mouse en el eje X y lo multiplica por la sensibilidad
            float rotacionY = Input.GetAxis("Mouse X") * rotateSpeed;

            // Rota el DIORAMA_PADRE alrededor del eje Y (vertical)
            targetDiorama.Rotate(Vector3.up, rotacionY, Space.World);
        }

        // -------- ZOOM (CON RUEDA DEL MOUSE) --------

        // Obtiene el valor de la rueda del mouse (scroll)
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Si hay movimiento en la rueda
        if (scroll != 0.0f)
        {
            // Cambia el "Field of View" (FOV) de la cámara.
            // Restamos porque scroll "hacia arriba" (positivo) debe ACERCAR (reducir FOV)
            cam.fieldOfView -= scroll * zoomSpeed;

            // "Clamp" limita el valor para que no se pase de los mínimos y máximos
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFov, maxFov);
        }
    }
}

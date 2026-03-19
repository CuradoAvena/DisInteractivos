using UnityEngine;
using System.Collections;

public class EfectoDisolver : MonoBehaviour
{
    [Header("Configuración del Shader")]
    public string nombrePropiedad = "_DissolveAmount";
    public float duracionEfecto = 1.5f;

    private Material materialObjeto;

    void Start()
    {
        if (GetComponent<Renderer>() != null)
        {
            materialObjeto = GetComponent<Renderer>().material;
        }
    }

    // Esta función debe ser PÚBLICA para que el evento la pueda llamar
    public void IniciarDisolucion()
    {
        if (materialObjeto != null)
        {
            StartCoroutine(CorrutinaDisolver());
        }
    }

    IEnumerator CorrutinaDisolver()
    {
        float tiempo = 0f;
        while (tiempo < duracionEfecto)
        {
            tiempo += Time.deltaTime;
            float porcentaje = tiempo / duracionEfecto;
            materialObjeto.SetFloat(nombrePropiedad, porcentaje);
            yield return null;
        }

        Destroy(gameObject);
    }
}

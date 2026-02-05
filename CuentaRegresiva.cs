using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuentaRegresiva : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInicial = 60f; // Segundos para escapar
    public TextMeshProUGUI textoContador; // Arrastra tu texto aquí

    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        // Restar tiempo cada segundo
        tiempoRestante -= Time.deltaTime;

        // Actualizar el texto en pantalla (sin decimales)
        if (textoContador != null)
        {
            textoContador.text = Mathf.Round(tiempoRestante).ToString();
        }

        // ¿Se acabó el tiempo?
        if (tiempoRestante <= 0)
        {
            ReiniciarNivel();
        }
    }

    void ReiniciarNivel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestarTiempo(float cantidad)
    {
        tiempoRestante -= cantidad;

        // Efecto visual simple: Poner el texto rojo si te quitan tiempo
        if (textoContador != null) textoContador.color = Color.red;
    }
}
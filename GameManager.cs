using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI y Objetos")]
    public Image[] tachesUI;
    public GameObject panelDerrota;
    public GameObject objetoFinalOculto; // El diario, la llave, etc.

    [Header("Control")]
    public ControlDiorama controlDiorama;
    public int intentosMaximos = 3;

    // Si dejas esto VACÍO en el inspector, el juego termina y muestra el objeto.
    // Si escribes un nombre, el juego carga esa escena al ganar.
    public string nombreSiguienteNivel;

    private int erroresCometidos = 0;
    private int aciertosCometidos = 0;
    private int aciertosParaGanar; // Se calcula solo

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // 1. Cuenta automática de pistas en ESTA escena
        GameObject[] pistasEnEscena = GameObject.FindGameObjectsWithTag("Pista");
        aciertosParaGanar = pistasEnEscena.Length;

        Debug.Log("Meta del nivel: " + aciertosParaGanar + " pistas.");
    }

    public void RegistrarError()
    {
        if (erroresCometidos >= intentosMaximos) return;

        if (erroresCometidos < tachesUI.Length)
            tachesUI[erroresCometidos].color = Color.red;

        erroresCometidos++;

        if (erroresCometidos >= intentosMaximos)
        {
            if (panelDerrota != null) panelDerrota.SetActive(true);
            if (controlDiorama != null) controlDiorama.enabled = false;
        }
    }

    public void RegistrarAcierto()
    {
        if (aciertosCometidos >= aciertosParaGanar) return;

        aciertosCometidos++;

        // 2. ¿Llegamos a la meta de ESTA escena?
        if (aciertosCometidos >= aciertosParaGanar)
        {
            // AQUI ESTA LA LOGICA INTELIGENTE:

            // ¿El campo de texto está vacío?
            if (string.IsNullOrEmpty(nombreSiguienteNivel))
            {
                // CASO FINAL (Individual o Escena 2 de Equipo)
                Debug.Log("No hay siguiente nivel. Revelando Objeto Final.");
                if (objetoFinalOculto != null)
                {
                    objetoFinalOculto.SetActive(true);
                }
            }
            else
            {
                // CASO INTERMEDIO (Escena 1 de Equipo)
                Debug.Log("Cargando siguiente nivel: " + nombreSiguienteNivel);
                SceneManager.LoadScene(nombreSiguienteNivel);
            }
        }
    }

    public void IrAlSiguienteNivel()
    {
        // Esta función la usa el botón "Continuar" dentro del Panel Final (si lo usas)
        SceneManager.LoadScene(nombreSiguienteNivel);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

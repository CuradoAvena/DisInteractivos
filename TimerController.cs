using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeLimit = 60f;  // Tiempo l�mite en segundos
    private float currentTime;
    public TextMeshProUGUI  timerText;         // Texto para mostrar el tiempo
    public GameObject endGamePanel; // Panel de fin de juego
    public Button restartButton;    // Bot�n de reinicio

    void Start()
    {
        currentTime = timeLimit;
        endGamePanel.SetActive(false); // Aseg�rate de que el panel est� oculto al principio

        // Asigna el evento para el bot�n de reinicio
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        // Reducir el tiempo
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            if (!endGamePanel.activeInHierarchy)  // Solo mostrar si no est� activo
            {
                EndGame(); // Llamamos al m�todo para mostrar la pantalla de fin de juego
            }
        }
    }

    void UpdateTimerText()
    {
        // Actualiza el texto del temporizador con el tiempo restante
        timerText.text = Mathf.Ceil(currentTime).ToString();
    }

    void EndGame()
    {
        // Muestra el panel de fin de juego
        endGamePanel.SetActive(true);

        // Detenemos el temporizador
        Time.timeScale = 0f;  // Esto detiene todo el juego (tambi�n puede detener animaciones y f�sica)
    }

    // M�todo para reiniciar el juego
    void RestartGame()
    {
        // Ocultamos el panel de fin de juego
        endGamePanel.SetActive(false);

        // Reseteamos el tiempo
        currentTime = timeLimit;

        // Restablecemos el temporizador
        Time.timeScale = 1f;  // Reiniciamos el juego (reactiva el flujo de tiempo)

        // Opcional: Puedes agregar l�gica para reiniciar otras partes del juego, como posiciones de cartas, etc.
    }
}

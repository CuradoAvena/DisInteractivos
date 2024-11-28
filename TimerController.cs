using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeLimit = 60f;  // Tiempo límite en segundos
    private float currentTime;
    public TextMeshProUGUI  timerText;         // Texto para mostrar el tiempo
    public GameObject endGamePanel; // Panel de fin de juego
    public Button restartButton;    // Botón de reinicio

    void Start()
    {
        currentTime = timeLimit;
        endGamePanel.SetActive(false); // Asegúrate de que el panel esté oculto al principio

        // Asigna el evento para el botón de reinicio
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
            if (!endGamePanel.activeInHierarchy)  // Solo mostrar si no está activo
            {
                EndGame(); // Llamamos al método para mostrar la pantalla de fin de juego
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
        Time.timeScale = 0f;  // Esto detiene todo el juego (también puede detener animaciones y física)
    }

    // Método para reiniciar el juego
    void RestartGame()
    {
        // Ocultamos el panel de fin de juego
        endGamePanel.SetActive(false);

        // Reseteamos el tiempo
        currentTime = timeLimit;

        // Restablecemos el temporizador
        Time.timeScale = 1f;  // Reiniciamos el juego (reactiva el flujo de tiempo)

        // Opcional: Puedes agregar lógica para reiniciar otras partes del juego, como posiciones de cartas, etc.
    }
}

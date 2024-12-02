using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControl1 : MonoBehaviour
{
    public enum GameLevel { Level1, Level2 }
    public GameLevel currentLevel = GameLevel.Level1;

    public bool IsFlippingInProgress = false; // Para evitar interacciones durante la comparaci�n
    private List<Card> flippedCards = new List<Card>(); // Lista de cartas volteadas
    private int totalMatches = 0; // Contador de coincidencias realizadas
    private int cardsPerMatch = 2; // Cambia seg�n el nivel
    private int totalCards; // N�mero total de cartas en la escena
    public bool isGameActive = true; // Controla si el juego est� activo

    private void Start()
    {
        UpdateLevelSettings(); // Configura el nivel inicial
        totalCards = FindObjectsOfType<Card>().Length; // Cuenta cu�ntas cartas hay en la escena

        if (totalCards % cardsPerMatch != 0)
        {
            Debug.LogError($"El n�mero total de cartas debe ser m�ltiplo de {cardsPerMatch}.");
        }
    }

    public void CardFlipped(Card card)
    {
        // Evitar interacci�n si el juego no est� activo, ya hay comparaci�n en progreso, o la carta ya est� emparejada
        if (!isGameActive || IsFlippingInProgress || flippedCards.Contains(card) || card.isMatched)
        {
            return;
        }

        flippedCards.Add(card);
        card.ShowFace();

        if (flippedCards.Count == cardsPerMatch)
        {
            IsFlippingInProgress = true;
            StartCoroutine(CompareCards());
        }
    }

    private IEnumerator CompareCards()
    {
        yield return new WaitForSeconds(1);

        // Verifica si todas las cartas volteadas tienen el mismo �ndice
        bool isMatch = true;
        int firstIndex = flippedCards[0].faceIndex;

        foreach (var card in flippedCards)
        {
            if (card.faceIndex != firstIndex)
            {
                isMatch = false;
                break;
            }
        }

        if (isMatch)
        {
            HandleMatch();
        }
        else
        {
            HandleMismatch();
        }

        flippedCards.Clear();
        IsFlippingInProgress = false;
    }

    private void HandleMatch()
    {
        foreach (var card in flippedCards)
        {
            card.SetMatched();
            Destroy(card.gameObject);
        }

        totalMatches++;

        // Comprueba si el nivel est� completo
        if (IsLevelComplete())
        {
            AdvanceToNextLevel();
        }
    }

    private void HandleMismatch()
    {
        foreach (var card in flippedCards)
        {
            card.ShowBack();
        }
    }

    private bool IsLevelComplete()
    {
        // Verificar si todas las cartas han sido emparejadas
        int unmatchedCards = FindObjectsOfType<Card>().Count(card => !card.isMatched);
        return unmatchedCards == 0; // Si no hay cartas sin emparejar, el nivel est� completo
    }

    private void AdvanceToNextLevel()
    {
        if (currentLevel == GameLevel.Level1)
        {
            currentLevel = GameLevel.Level2;
            RestartLevel();
        }
        else if (currentLevel == GameLevel.Level2)
        {
            Debug.Log("�Juego completado!");
            EndGame();
        }
    }

    private void RestartLevel()
    {
        // Reinicia el estado del juego
        isGameActive = true;
        totalMatches = 0;
        flippedCards.Clear();

        // Destruye las cartas anteriores
        CardSpawner cardSpawner = FindObjectOfType<CardSpawner>();

        // Accede al contenedor correcto seg�n el nivel
        if (currentLevel == GameLevel.Level1)
        {
            foreach (Transform child in cardSpawner.cardContainerLevel1)
            {
                Destroy(child.gameObject);
            }
        }
        else if (currentLevel == GameLevel.Level2)
        {
            foreach (Transform child in cardSpawner.cardContainerLevel2)
            {
                Destroy(child.gameObject);
            }
        }

        // Genera nuevas cartas y ajusta la configuraci�n del nivel
        UpdateLevelSettings();
        cardSpawner.SpawnCards();
    }

    private void UpdateLevelSettings()
    {
        if (currentLevel == GameLevel.Level1)
        {
            cardsPerMatch = 2; // Emparejar pares
        }
        else if (currentLevel == GameLevel.Level2)
        {
            cardsPerMatch = 3; // Emparejar tr�os
        }

        totalCards = FindObjectsOfType<Card>().Length; // Aseg�rate de contar correctamente las cartas al cambiar de nivel
    }

    public void RestartGame()
    {
        // Reinicia todo el juego
        currentLevel = GameLevel.Level1;
        RestartLevel();
    }

    public void EndGame()
    {
        isGameActive = false; // Desactiva el juego
        Debug.Log("Juego terminado.");
    }
}


using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab de la carta
    public Sprite[] faces;       // Array de imágenes para las caras de las cartas
    public Sprite back;          // Sprite para el reverso de las cartas
    public Transform cardContainerLevel1;  // Contenedor para las cartas del Nivel 1
    public Transform cardContainerLevel2;  // Contenedor para las cartas del Nivel 2

    private void Start()
    {
        if (faces.Length < 4)
        {
            Debug.LogError("Se necesitan al menos 4 imágenes para jugar.");
            return;
        }

        SpawnCards();
    }

    public void SpawnCards()
    {
        int cardCount = 0;
        int groupSize = 0;

        // Configuración por nivel
        if (FindObjectOfType<GameControl1>().currentLevel == GameControl1.GameLevel.Level1)
        {
            cardCount = 8; // Total de cartas para Nivel 1 (4 pares)
            groupSize = 2; // Tamaño del grupo (pares)

            // Generar índices para las cartas en Nivel 1
            List<int> cardIndices = GenerateCardIndices(cardCount, groupSize);

            // Barajar los índices
            ShuffleList(cardIndices);

            // Fijar filas y columnas en 2 filas y 4 columnas
            int rows = 2;
            int columns = 4;
            float xOffset = 2.5f; // Espacio horizontal entre cartas
            float yOffset = 3.0f; // Espacio vertical entre cartas

            // Posición inicial para centrar las cartas
            float startX = -(columns - 1) * xOffset / 2;
            float startY = (rows - 1) * yOffset / 2;

            // Instanciar cartas
            for (int i = 0; i < cardCount; i++)
            {
                GameObject card = Instantiate(cardPrefab, cardContainerLevel1); // Colocar en el contenedor del Nivel 1
                int x = i % columns;
                int y = i / columns;

                // Posicionar la carta
                card.transform.position = new Vector2(startX + x * xOffset, startY - y * yOffset);

                // Configurar la carta
                card.GetComponent<Card>().InitializeCard(cardIndices[i], faces, back, FindObjectOfType<GameControl1>());
            }
        }
        else if (FindObjectOfType<GameControl1>().currentLevel == GameControl1.GameLevel.Level2)
        {
            cardCount = 12; // Total de cartas para Nivel 2 (6 tríos)
            groupSize = 3; // Tamaño del grupo (tríos)

            // Generar índices para las cartas en Nivel 2
            List<int> cardIndices = GenerateCardIndices(cardCount, groupSize);

            // Barajar los índices
            ShuffleList(cardIndices);

            // Fijar filas y columnas en 3 filas y 4 columnas
            int rows = 3;
            int columns = 4;
            float xOffset = 2.5f; // Espacio horizontal entre cartas
            float yOffset = 3.0f; // Espacio vertical entre cartas

            // Posición inicial para centrar las cartas
            float startX = -(columns - 1) * xOffset / 2;
            float startY = (rows - 1) * yOffset / 2;

            // Instanciar cartas
            for (int i = 0; i < cardCount; i++)
            {
                GameObject card = Instantiate(cardPrefab, cardContainerLevel2); // Colocar en el contenedor del Nivel 2
                int x = i % columns;
                int y = i / columns;

                // Posicionar la carta
                card.transform.position = new Vector2(startX + x * xOffset, startY - y * yOffset);

                // Configurar la carta
                card.GetComponent<Card>().InitializeCard(cardIndices[i], faces, back, FindObjectOfType<GameControl1>());
            }
        }
    }

    private List<int> GenerateCardIndices(int cardCount, int groupSize)
    {
        List<int> indices = new List<int>();

        int groupCount = cardCount / groupSize;
        for (int i = 0; i < groupCount; i++)
        {
            for (int j = 0; j < groupSize; j++)
            {
                indices.Add(i);
            }
        }

        return indices;
    }

    private void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}

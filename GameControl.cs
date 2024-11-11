using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControl : MonoBehaviour
{
 public GameObject cartaPrefab;
    public Sprite[] faceSprites; // Array de las imágenes de las caras de las cartas
    public Sprite backSprite; // Imagen de reverso de la carta

    private List<int> faceIndices = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 }; // Índices para parejas
    private System.Random rnd = new System.Random();

    private void Start()
    {
        float startX = -3f;  // Posición inicial en X
        float startY = 2.5f; // Posición inicial en Y
        float xOffset = 2.5f; // Espacio entre cartas en X
        float yOffset = 3.0f; // Espacio entre cartas en Y

        int columns = 4;
        int rows = 2;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = rnd.Next(faceIndices.Count);
                int faceIndex = faceIndices[index];
                faceIndices.RemoveAt(index);

                // Crear una instancia de la carta
                Vector3 position = new Vector3(startX + j * xOffset, startY - i * yOffset, 0);
                var carta = Instantiate(cartaPrefab, position, Quaternion.identity);
                carta.GetComponent<Card>().InitializeCard(faceIndex, faceSprites, backSprite);
            }
        }
    }

}

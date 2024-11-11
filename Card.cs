using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = false;
    public int faceIndex;
    private Sprite[] faces;
    private Sprite back;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = back; // Comienza con el reverso visible
    }

    // Inicializa la carta con un índice y asigna las imágenes
    public void InitializeCard(int index, Sprite[] faceSprites, Sprite backSprite)
    {
        faceIndex = index;
        faces = faceSprites;
        back = backSprite;
        spriteRenderer.sprite = back;
    }

    // Método que se llama al hacer clic en la carta
    private void OnMouseDown()
    {
        if (!isFlipped)
        {
            ShowFace();
        }
        else
        {
            ShowBack();
        }
        isFlipped = !isFlipped;
    }

    // Muestra la cara de la carta
    private void ShowFace()
    {
        spriteRenderer.sprite = faces[faceIndex];
    }

    // Muestra el reverso de la carta
    private void ShowBack()
    {
        spriteRenderer.sprite = back;
    }
}

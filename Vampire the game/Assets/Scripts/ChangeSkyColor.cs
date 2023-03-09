using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeSkyColor : MonoBehaviour
{
    public TilemapRenderer tilemapRenderer;
    public Color color = new Color(1f, 0f, 0f, 0.7f);  // kolor do zmiany

    void Start()
    {
        tilemapRenderer.material.color = color;
    }
}
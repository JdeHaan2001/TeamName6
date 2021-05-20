using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerlinNoiseGenerator : MonoBehaviour
{
    private int width = 256;
    private int height = 256;

    [SerializeField] private float scale = 20f;
    [SerializeField] private Vector2 _offSet;

    private Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);
        _offSet = new Vector2(Random.Range(0f, 99999f), Random.Range(0f, 99999f));

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + _offSet.x;
        float yCoord = (float)y / height * scale + _offSet.y;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}

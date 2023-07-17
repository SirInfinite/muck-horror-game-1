using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FalloffGenerator
{

    public static float[,] GenerateFalloffMap(Vector2Int size, float falloffStart, float falloffEnd)
    {
        float[,] heightMap = new float[size.x, size.y];

        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                Vector2 position = new Vector2(
                (float)x / size.x * 2 - 1,
                (float)y / size.y * 2 - 1
                );

                float t = Mathf.Max(Mathf.Abs(position.x), Mathf.Abs(position.y));
                if (t < falloffStart)
                {
                    heightMap[x, y] = 1; 
                } else if (t > falloffEnd) 
                {
                    heightMap[x, y] = 0;
                } else
                {
                    heightMap[x, y] = Mathf.SmoothStep(1, 0, Mathf.InverseLerp(falloffStart, falloffEnd, t));
                }
            }
        }

        int sizeX = heightMap.GetLength(0);
        int sizeY = heightMap.GetLength(1);

        // Invert the heightmap values
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                heightMap[x, y] = 1 - heightMap[x, y];
            }
        }

        return heightMap;
    }

    static float Evaluate(float value)
    {
        float a = 3;
        float b = 2.2f;

        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }
}

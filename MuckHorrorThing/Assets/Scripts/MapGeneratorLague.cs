using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorLague : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public void GenerateMap()
    {
        float[,] noiseMap = PerlinNoise.GenerateNoiseMap (mapWidth, mapHeight, noiseScale);
    
        MapDisplay display = FindObjestOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }
}

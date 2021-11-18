using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGeneration : MonoBehaviour
{
    public Texture2D map;
    public Tilemap tilemap;
    public ColorToTilemap[] colorMappings;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for(int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.width; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x, int y) {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
            return;

        tilemap.SetTile(new Vector3Int(x,y,0), colorMappings[0].tile);

    }
}

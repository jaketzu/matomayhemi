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

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);


        

        print(pixelColor);
        print(colorMappings[1].color + "    YYYYYYYYYYxd");
        //for (int i = 0; i < colorMappings.Length; i++)
        //{

        //    if (colorMappings[i].color == pixelColor)
        //    {
        //        tilemap.SetTile(new Vector3Int(x, y, 0), colorMappings[i].tile);

        //    }

        //}

        if(colorMappings[0].color == pixelColor)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), colorMappings[0].tile);
            return;
        }
        if (colorMappings[1].color == pixelColor)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), colorMappings[1].tile);
            return;
        }
        if (colorMappings[2].color == pixelColor)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), colorMappings[2].tile);
            return;
        }
    }
}

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


        
        
        for (int i = 0; i < colorMappings.Length; i++)
        {
            
            if(pixelColor.a == 0){
                return;
            }
            
            if (CompareColors(pixelColor, colorMappings[i].color))
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), colorMappings[i].tile);

            }

        }
    }

    bool CompareColors(Color first, Color second){
        string hexCode = ColorUtility.ToHtmlStringRGB(first);
        string hexCode2 = ColorUtility.ToHtmlStringRGB(second);
        
        /*  print(hexCode); */

        return (hexCode == hexCode2);
    }
}

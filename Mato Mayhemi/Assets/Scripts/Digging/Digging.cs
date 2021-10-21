using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Digging : MonoBehaviour
{
    public Tilemap tilemap;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3Int pos = Vector3Int.FloorToInt(gameObject.transform.position);

        for(int x = pos.x - 4; x < (pos.x + 4); x++)
        {
            for(int y = pos.y - 4; y < (pos.y + 4); y++)
            {
                float distance = Mathf.Sqrt( Mathf.Pow(x,2) + Mathf.Pow(y, 2));

                if(distance < 3f)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
                
                
            }
        }

        
        
    }
    
}

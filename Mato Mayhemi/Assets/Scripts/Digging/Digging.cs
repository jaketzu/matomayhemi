using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Digging : MonoBehaviour
{
    public Tilemap tilemap;

    float add = 30;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 pos = gameObject.transform.position;

        for(float x = pos.x - add; x < (pos.x + add); x++)
        {
            for(float y = pos.y - add; y < (pos.y + add); y++)
            {
                float dc = x * x;
                float dr = y * y;
                if (dc+dr <= 16*16)
                {
                    
                    tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(x),Mathf.RoundToInt(y),0),null);
                }
                
                
            }
        }

        
        
    }
   
    
}

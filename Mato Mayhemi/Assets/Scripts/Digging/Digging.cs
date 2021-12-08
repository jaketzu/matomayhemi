using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Digging : MonoBehaviour
{
    public Tilemap tilemap;

    public float add;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.GetContact(0).point);
        Vector3 pos = collision.GetContact(0).point;
        
        for(float x = pos.x - add; x < (pos.x + add); x++)
        {
            for(float y = pos.y - add; y < (pos.y + add); y++)
            {
                float dc = x * x;
                float dr = y * y;
                if (dc+dr <= 16*16)
                {
                    Vector3Int tilepos = tilemap.WorldToCell(pos + new Vector3(x,y,0));

                    if(tilemap.GetTile(tilepos) != null){
                        tilemap.SetTile(tilepos,null);
                    }
                    
                }
                
                
            }
        }

        
        
    }
   
    
}

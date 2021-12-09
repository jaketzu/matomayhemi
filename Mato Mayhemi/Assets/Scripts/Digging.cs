using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Digging : MonoBehaviour
{
    Tilemap tilemap;

    public float radius;
    float add;
    
    void Start()
    {
        add = radius + 100;

        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.GetContact(0).point);
        Vector3 pos = collision.GetContact(0).point;
        
        for(float x = pos.x - add; x < (pos.x + add); x++)
        {
            for(float y = pos.y - add; y < (pos.y + add); y++)
            {
                float dc = x * x;
                float dr = y * y;
                if (dc+dr <= radius*radius)
                {
                    Vector3Int tilepos = tilemap.WorldToCell(pos + new Vector3(x,y,0));

                    if(tilemap.GetTile(tilepos) != null){
                        tilemap.SetTile(tilepos,null);
                    }
                    
                }
            }
        }
        Destroy(gameObject);
    }*/

    public void DestroyEnvironment()
    {
        Vector2 pos = transform.position;
        
        for(float x = pos.x - add; x < (pos.x + add); x++)
        {
            for(float y = pos.y - add; y < (pos.y + add); y++)
            {
                float dc = x * x;
                float dr = y * y;
                if (dc+dr <= radius * radius)
                {
                    Vector3Int tilepos = tilemap.WorldToCell(pos + new Vector2(x, y));

                    if(tilemap.GetTile(tilepos) != null){
                        tilemap.SetTile(tilepos,null);
                    }
                    
                }
            }
        }
    }
}

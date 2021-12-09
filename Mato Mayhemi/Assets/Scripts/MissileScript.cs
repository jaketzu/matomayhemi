using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public string shooter;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //takedamage player
            //boom
            //riko environment
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            //boom
            //riko environment
            Destroy(gameObject);
        }
    }
}

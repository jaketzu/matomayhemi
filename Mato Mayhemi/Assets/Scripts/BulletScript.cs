using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string shooter;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //takedamage player
            //riko environment
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            //riko environment
            Destroy(gameObject);
        }
    }
}

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
            collision.gameObject.GetComponent<Player>().TakeDamage(15);
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            //riko environment
            Destroy(gameObject);
        }
    }
}

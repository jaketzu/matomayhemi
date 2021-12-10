using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage;

    public GameObject explosion;
    public AudioClip hit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject flame = Instantiate(explosion, transform.position, Quaternion.identity);
        flame.transform.localScale = new Vector3(2, 2, 1);
        flame.GetComponent<AudioSource>().clip = hit;

        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

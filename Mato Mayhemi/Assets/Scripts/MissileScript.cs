using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public int damage;
    public int force;
    public float radius;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

        //boom
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
        for (int i = 0; i < hit.Length; i++)
        {
            print(hit[i].collider.name);
            if(hit[i].collider.CompareTag("Player"))
            {
                Vector2 direction = new Vector2(hit[i].transform.position.x - transform.position.x, hit[i].transform.position.y - transform.position.y);
                hit[i].collider.GetComponent<Player>().TakeDamage(damage);
                hit[i].collider.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
            }
            else if(hit[i].collider.CompareTag("Ground"))
            {
                //tuhoa ympäristöä
            }
        }
        Destroy(gameObject);
    }
}

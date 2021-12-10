using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public int damage;
    public int force;
    public float radius;
    public LayerMask layerMask;
    public AudioSource audioSource;

    public float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            audioSource.Play();
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, transform.right, 0, layerMask);
            if(hit != null)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if(hit[i].collider.CompareTag("Player"))
                    {
                        Vector2 direction = new Vector2(hit[i].transform.position.x - transform.position.x, hit[i].transform.position.y - transform.position.y);
                        hit[i].collider.GetComponent<Player>().TakeDamage(damage);
                        hit[i].collider.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
                    }
                    else if(hit[i].collider.CompareTag("Ground"))
                    {
                        gameObject.GetComponent<Digging>().DestroyEnvironment();
                    }
                }
            }
            
            Destroy(gameObject);
        }
    }
}

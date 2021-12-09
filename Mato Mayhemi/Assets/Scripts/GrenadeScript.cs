using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public int damage;
    public int force;
    public float radius;

    public float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
            for (int i = 0; i < hit.Length; i++)
            {
                if(hit[i].collider.CompareTag("Player"))
                {
                    float angle = Mathf.Atan2(hit[i].transform.position.y - transform.position.y, hit[i].transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
                    //Vector2 direction = 
                    hit[i].collider.GetComponent<Player>().TakeDamage(damage);
                    //hit[i].collider.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
                }
                else if(hit[i].collider.CompareTag("Ground"))
                {
                    //tuhoa ympäristöä
                }
            }
            Destroy(gameObject);
        }
    }
}

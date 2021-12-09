using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyGrenade : MonoBehaviour
{
    GamepadControls gc;

    private CircleCollider2D cc;

    public float force;
    public float timer;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();
        gc.Game.Shoot.performed += ctx => Shoot();

        cc = GetComponent<CircleCollider2D>();
    }

    //ohjainhommii
    void OnEnable()
    {
        gc.Enable();
    }

    //ohjainhommii
    void OnDisable()
    {
        gc.Disable();
    }

    void Update() 
    {
        if(transform.parent = null)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                //explode
                Destroy(gameObject);
            }
        }
    }

    public void Shoot()
    {
        if (transform.parent != null)
        {
            GameObject grenade = Instantiate(gameObject, transform.position, transform.rotation);
            grenade.AddComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
            grenade.GetComponent<CircleCollider2D>().enabled = true;

            Destroy(gameObject);
        }
    }
}
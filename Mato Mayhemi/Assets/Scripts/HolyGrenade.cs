using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyGrenade : MonoBehaviour
{
    GamepadControls gc;

    private Rigidbody2D rb;
    private CircleCollider2D cc;

    public float force;
    private bool thrown;
    public float timer;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();
        gc.Game.Shoot.performed += ctx => Shoot();

        rb = GetComponent<Rigidbody2D>();
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

    void Start()
    {
        rb.gravityScale = 0;
        cc.enabled = false;
    }

    void Update() 
    {
        if(thrown)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                //explode
                Destroy(gameObject);
            }
        }
    }

    void Shoot()
    {
        thrown = true;
        transform.parent = null;
        rb.gravityScale = 1;
        cc.enabled = true;
        GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
    }
}
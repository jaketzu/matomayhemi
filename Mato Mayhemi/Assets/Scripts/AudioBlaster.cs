using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBlaster : MonoBehaviour
{
    GamepadControls gc;

    public float size;
    public float force;

    private Transform muzzle;

    void Awake()
    {
        gc = new GamepadControls();
        gc.Game.Shoot.performed += ctx => Shoot();

        muzzle = transform.GetChild(1);
    }

    void OnEnable()
    {
        gc.Enable();
    }

    void OnDisable()
    {
        gc.Disable();
    }

    void Shoot()
    {
        Vector2 direction = new Vector2(transform.parent.parent.position.x - transform.position.x, transform.parent.parent.position.y - transform.position.y);

        RaycastHit2D[] hit = Physics2D.BoxCastAll(muzzle.position, new Vector2(size, size), transform.rotation.z, transform.up);
        for (int i = 0; i < hit.Length; i++)
        {
            if(hit[i].collider.CompareTag("Player"))
            {
                hit[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
            }

            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}

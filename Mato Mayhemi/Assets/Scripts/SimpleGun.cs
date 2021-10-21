using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    GamepadControls gc;

    private Rigidbody2D rb;
    public float force;
    public Transform muzzle;
    public GameObject bullet;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.Shoot.performed += ctx => Shoot();
    }

    void OnEnable()
    {
        gc.Enable();
    }

    void OnDisable()
    {
        gc.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        muzzle = transform.GetChild(0);
    }

    void Shoot()
    {
        bullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
    }
}

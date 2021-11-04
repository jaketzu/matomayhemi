using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    GamepadControls gc;

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
        muzzle = transform.GetChild(0);
    }

    void Shoot()
    {
        bullet = Instantiate(bullet, muzzle.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(muzzle.up * force, ForceMode2D.Impulse);
    }
}

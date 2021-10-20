using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public Transform muzzle;
    public GameObject bullet;

    void Start()
    {
        rb = bullet.GetComponent<Rigidbody2D>();
        muzzle = transform.GetChild(0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) //vaiha uuempaan input systeemiin
            Shoot();
    }

    void Shoot()
    {
        bullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    GamepadControls gc;

    public float force;

    private Transform muzzle;
    public GameObject bulletPrefab;

    public int shotCount;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();
        gc.Game.Shoot.performed += ctx => Shoot();

        muzzle = transform.GetChild(1);
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

    void Shoot()
    {    
        //kunnes ollaan ammuttu kaikki ammukset
        for (int i = 0; i < shotCount; i++)
        {
            //instatioidaan ammus aseen suusta ja lisätään siihen voimaa
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(muzzle.up * force, ForceMode2D.Impulse);
        }
    }
}

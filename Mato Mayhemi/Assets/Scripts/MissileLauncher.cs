using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    GamepadControls gc;

    public float force;

    private Transform muzzle;
    public GameObject missilePrefab;

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
        GameObject missile = Instantiate(missilePrefab, muzzle.position, transform.rotation);
        missile.GetComponent<Rigidbody2D>().AddForce(muzzle.up * force, ForceMode2D.Impulse);
    }
}

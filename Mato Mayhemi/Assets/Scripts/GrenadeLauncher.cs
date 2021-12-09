using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    GamepadControls gc;

    public float force;
    private Transform muzzle;
    public GameObject bombPrefab;

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
        GameObject bomb = Instantiate(bombPrefab, muzzle.position, transform.rotation);
        bomb.GetComponent<Rigidbody2D>().AddForce(muzzle.up * force, ForceMode2D.Impulse);
    }
}

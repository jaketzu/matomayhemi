using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public int damage;
    public int force;

    public float radius;
    public int shots;

    public float firerate;
    public float nextTimeToFire;

    void Start()
    {
        nextTimeToFire = 0;
    }
}

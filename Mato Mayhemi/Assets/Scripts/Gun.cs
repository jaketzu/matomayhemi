using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    [HideInInspector]public Transform muzzle;

    public int damage;
    public int force;
    public int shots;

    public float firerate;
    [HideInInspector]public float nextTimeToFire = 0;

    void Awake() 
    {
        muzzle = transform.GetChild(1);
    }
}

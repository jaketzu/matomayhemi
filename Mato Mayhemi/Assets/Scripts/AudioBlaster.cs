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
        //katsotaan aseen suunta
        Vector2 direction = transform.up;

        //raycastataan laatikko aseen suusta eteenpäin tietyllä koolla ja talletetaan kaikki colliderit johon laatikko osuu
        RaycastHit2D[] hit = Physics2D.BoxCastAll(muzzle.position, new Vector2(size, size), transform.rotation.z, direction);
        //mennään kaikkien laatikon osumien objektejien läpi
        for (int i = 0; i < hit.Length; i++)
        {
            //jos objekti on pelaaja, lisätään pelaajalle voimaa aseen suuntaan
            if(hit[i].collider.CompareTag("Player"))
            {
                hit[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
            }

            //lisätään voimaa aseen vastakkaiseen suuntaan pelaajalle joka pitää asetta
            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(-direction * force, ForceMode2D.Impulse);
        }
    }
}

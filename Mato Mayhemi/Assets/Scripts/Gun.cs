using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GamepadControls gc;

    public GameObject bulletPrefab;
    private Transform muzzle;

    public int damage;
    public int force;
    public int shots;

    public float firerate;
    float nextTimeToFire = 0;


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

    public void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firerate;

            if (bulletPrefab != null)
            {
                for (int i = 0; i < shots; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, muzzle.position, transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
                }
            }
            else if (transform.name == "Railgun")
            {
                LineRenderer lr = transform.GetChild(1).GetComponent<LineRenderer>();
                lr.enabled = true;

                RaycastHit2D hitRail = Physics2D.Raycast(muzzle.position, transform.up, 1000f);
                StartCoroutine(DrawRope(hitRail.point, lr));

                if (hitRail.collider.CompareTag("Player"))
                {
                    //takedamage player
                }
                else
                {
                    //ymp‰ristˆ posahus
                }
            }
            else if (transform.name == "Audio Blaster")
            {
                //katsotaan aseen suunta
                Vector2 direction = transform.up;

                //raycastataan laatikko aseen suusta eteenp‰in tietyll‰ koolla ja talletetaan kaikki colliderit johon laatikko osuu
                RaycastHit2D[] hitAB = Physics2D.BoxCastAll(muzzle.position, new Vector2(3, 3), transform.rotation.z, direction);
                //menn‰‰n kaikkien laatikon osumien objektejien l‰pi
                for (int i = 0; i < hitAB.Length; i++)
                {
                    //jos objekti on pelaaja, lis‰t‰‰n pelaajalle voimaa aseen suuntaan
                    if (hitAB[i].collider.CompareTag("Player"))
                    {
                        hitAB[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
                    }

                    //lis‰t‰‰n voimaa aseen vastakkaiseen suuntaan pelaajalle joka pit‰‰ asetta
                    transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(-direction * force, ForceMode2D.Impulse);
                }
            }
        }
    }
    
    private IEnumerator DrawRope(Vector2 hitPoint, LineRenderer lr)
    {
        Vector2 currentPos = new Vector2(muzzle.position.x, muzzle.position.y);
        lr.SetPosition(0, currentPos);
        lr.SetPosition(1, hitPoint);

        yield return new WaitForSeconds(0.5f);

        lr.enabled = false;

    }
}

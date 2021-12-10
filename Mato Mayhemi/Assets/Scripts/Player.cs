using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private int playerIndex = 0;
    public int health;

    [HideInInspector]public float moveHor;
    [HideInInspector]public float moveVer;
    private Vector2 moveDir;
    public float deadzone;
    public float speed;
    public float force;

    public float jumpVel;
    public float jumps;
    [SerializeField] private float jumpsLeft;

    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private BoxCollider2D[] bc = new BoxCollider2D[2];

    [SerializeField]private Animator anim;

    [SerializeField]private SpringJoint2D joint;

    [SerializeField] private LayerMask groundLayerMask;

    private Transform gun;
    private Gun gunScript;

    public GameObject explosion;

    [SerializeField]private LineRenderer lr;

    [SerializeField] private AudioSource audioSource;

    private bool rope;
    public float ropeAdjust;

    public LayerMask grappleLayerMask;
    private Vector2 grapplePoint;
    private float distance;

    public Transform weaponHolder;
    private int previousWeapon;
    private int selected;

    [HideInInspector]public float aimHor;
    [HideInInspector]public float aimVer;

    private float angle;

    private Vector2 aimDir;

    [HideInInspector]public bool isShoot;
    [HideInInspector]public bool isJump;
    [HideInInspector]public bool isRope;
    [HideInInspector]public bool isSwitch;

    private Vector2 rayDir;

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    void Start()
    {   

        jumpsLeft = jumps;

        rope = false;

        joint.enabled = false;

        lr.enabled = false;

        //asetetaan valittu ase ensimm�iseksi
        selected = -1;
        SwitchGun();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, rayDir);
    }

    void Update()
    {
        moveDir = new Vector2(moveHor, moveVer);

        //jos on liikettä ja et ole ropessa
        if (moveDir.magnitude > deadzone && !joint.enabled)
        {
            //t�m� on sit� varten ett� jos tulee ropesta transform.translate ei mene sekasin koska on voimaa rigidbodyssa
            rb.velocity = new Vector2(0, rb.velocity.y);

            //liikesuunta ja nopeus asetetaan
            Vector2 move = new Vector2(moveHor, 0) * speed * Time.deltaTime;
            //siirret��n pelaajaa
            transform.Translate(move, Space.World); //hullu

            //animaatiota
            if (moveHor < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (moveHor > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            anim.SetBool("Moving", true);
        }
        //jos olet ropessa
        else
        {
            RopeMove();
            anim.SetBool("Moving", false);
        }

        if(rope && moveDir.magnitude > deadzone && moveVer != 0)
            AdjustRope();

        aimDir = new Vector2(aimHor, aimVer);

        //katsoo onko tikut tarpeeksi kaukana keskelt�
        if (aimDir.magnitude > deadzone)
            Aim();

        if(isShoot)
            Shoot();

        if(isJump)
            Jump();

        if(isRope)
            Rope();
        
        if(isSwitch)
            SwitchGun();
    }

    void LateUpdate()
    {
        //jos rope on k�yt�ss�, piirret��n rope
        if (rope)
            DrawRope();
    }

    public void Jump()
    {
        //katsotaan onko meill� hyppyj� j�ljell� ja emme ole ropessa
        if (CheckGround() != 0 && !joint.enabled)
        {
            isJump = false;

            audioSource.Play();

            //lis�t��n voimaa rigidbodyyn
            rb.velocity = Vector2.up * jumpVel;
            jumpsLeft--;
        }
    }

    public void Rope()
    {
        isRope = false;
        //jos rope ei ole k�yt�ss�
        if (!rope)
        {
            rope = true;

            //disabloidaan pelaajan colliderit frameksi, jotta raycast ei osu omaan pelaajaan
            bc[0].enabled = false;
            bc[1].enabled = false;

            //raycastataan pelaajan kohdasta aseesta yl�sp�in
            RaycastHit2D hit = Physics2D.Raycast(transform.position, gun.up, 100f, grappleLayerMask); //laske jotenkin ilman aseen transformista
            if (hit.collider != null)
            {
                //asetetaan grapplepoint raycastin osumaan kohtaan
                grapplePoint = hit.point;

                lr.enabled = true;

                //enabloidaan pelaajan springjoint
                joint.enabled = true;
                //yhdistet��n springjoint osuttuun sein��n
                joint.connectedAnchor = grapplePoint;
                //asetetaan springjointin pituus pelaajan ja grapplepointin v�liseksi pituudeksi
                distance = Vector2.Distance(transform.position, grapplePoint);
                joint.distance = distance;
            }

            //enabloidaan pelaajan colliderit
            bc[0].enabled = true;
            bc[1].enabled = true;
        }
        else
        {
            rope = false;

            joint.enabled = false;

            lr.enabled = false;
        }
    }
    
    void DrawRope()
    {
        //piirret��n viiva pelaajasta grapplepointtiin
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, grapplePoint);
    }

    public void RopeMove()
    {
        //jos olemme ropessa
        if(rope)
        {
            //emme k�ytet� transform.translate vain lis�t��n voimaa rigidbodyyn
            Vector2 move = new Vector2(moveHor, 0) * force * Time.deltaTime;
            rb.AddForce(move);
        }
    }

    public void AdjustRope()
    {
        joint.distance -= moveVer * ropeAdjust * Time.deltaTime;
    }

    private float CheckGround()
    {
        //raycastataan laatikko pelaajan alle jotta voimme katsoa koskeeko maata
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc[0].bounds.center, bc[0].bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        if (raycastHit.collider != null)
        {
            //jos koskemme maahan resetataan hypyt
            jumpsLeft = jumps;
        }
        //palautetaan hyppyjen m��r�
        return jumpsLeft;
    }

    public void Aim()
    {
        //aseen positio asetetaan verrattuna pelaajaan oikean tikun mukaan
        gun.position = new Vector2(transform.position.x + aimDir.normalized.x, transform.position.y + aimDir.normalized.y);

        //aseen rotaatio asetetaan laskemalla pelaajan ja aseen kulman k�ytt�en tan
        angle = Mathf.Atan2(gun.position.y - transform.position.y, gun.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        gun.eulerAngles = new Vector3(0, 0, angle); //aseen rotaatio asetetaan
    }

    public void Shoot()
    {
        isShoot = false;
        if (Time.time >= gunScript.nextTimeToFire)
        {
            gunScript.audioSource.Play();
            gunScript.nextTimeToFire = Time.time + 1f / gunScript.firerate;

            if (gunScript.bulletPrefab != null)
            {
                GameObject flame = Instantiate(explosion, gunScript.muzzle.position, Quaternion.identity);
                flame.transform.parent = gunScript.muzzle;

                if(gun.name == "Grenade Launcher(Clone)" || gun.name == "HeldHG(Clone)")
                {
                    GameObject bullet = Instantiate(gunScript.bulletPrefab, gunScript.muzzle.position, gun.transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(gun.transform.up * gunScript.force, ForceMode2D.Impulse);
                }
                else if(gun.name == "Missile Launcher(Clone)")
                {
                    GameObject bullet = Instantiate(gunScript.bulletPrefab, gunScript.muzzle.position, gun.transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(gun.transform.up * gunScript.force, ForceMode2D.Impulse);
                }
                else
                {
                    for (int i = 0; i < gunScript.shots; i++)
                    {
                        GameObject bullet = Instantiate(gunScript.bulletPrefab, gunScript.muzzle.position, gun.transform.rotation);
                        bullet.GetComponent<BulletScript>().damage = gunScript.damage;
                        bullet.GetComponent<Rigidbody2D>().AddForce(gun.transform.up * gunScript.force, ForceMode2D.Impulse);
                    }
                }
            }
            else if (gun.transform.name == "Railgun(Clone)")
            {
                LineRenderer lr = gun.transform.GetChild(1).GetComponent<LineRenderer>();
                lr.enabled = true;

                RaycastHit2D hitRail = Physics2D.Raycast(gunScript.muzzle.position, gun.transform.up, 1000f);
                StartCoroutine(DrawRay(hitRail.point, lr));

                if(hitRail.collider != null)
                {
                    if (hitRail.collider.CompareTag("Player"))
                    {
                        hitRail.collider.GetComponent<Player>().TakeDamage(gunScript.damage);
                    }
                }
            }
            else if (gun.transform.name == "Audio Blaster(Clone)")
            {
                Animator audioBlasterAnim = gun.GetComponent<Animator>();
                audioBlasterAnim.SetBool("Shoot", true);
                StartCoroutine("AudioAnim");
                //gun.GetComponent<Animator>().SetBool("Shoot", false);

                //katsotaan aseen suunta
                Vector2 direction = gun.transform.up;

                //raycastataan laatikko aseen suusta eteenp�in tietyll� koolla ja talletetaan kaikki colliderit johon laatikko osuu
                RaycastHit2D[] hitAB = Physics2D.BoxCastAll(gunScript.muzzle.position, new Vector2(3, 3), gun.rotation.z, direction);
                if(hitAB != null)
                {
                    //menn��n kaikkien laatikon osumien objektien läpi
                    for (int i = 0; i < hitAB.Length; i++)
                    {
                        {
                            //jos objekti on pelaaja, lis�t��n pelaajalle voimaa aseen suuntaan
                            if (hitAB[i].collider.CompareTag("Player"))
                            {
                                hitAB[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * gunScript.force, ForceMode2D.Impulse);
                            }
                        }

                        //lis�t��n voimaa aseen vastakkaiseen suuntaan pelaajalle joka pit�� asetta
                        rb.AddForce(-direction * gunScript.force, ForceMode2D.Impulse);
                    }
                
                }
            }
        }
    }

    IEnumerator AudioAnim()
    {
        yield return new WaitForSeconds(0.1f);
        gun.GetComponent<Animator>().SetBool("Shoot", false);
    }
    
    private IEnumerator DrawRay(Vector2 hitPoint, LineRenderer lr)
    {
        Vector2 currentPos = new Vector2(gunScript.muzzle.position.x, gunScript.muzzle.position.y);
        lr.SetPosition(0, currentPos);
        lr.SetPosition(1, hitPoint);

        yield return new WaitForSeconds(0.5f);

        lr.enabled = false;

    }

    public void SwitchGun()
    {
        isSwitch = false;
        //asetetaan nykyinen ase edelliseksi
        previousWeapon = selected;

        //jos valitun aseen numero menee pelaajan aseiden m��r�n yli asetetaan valittu ase takaisin ensimm�iseksi
        if (selected >= transform.GetChild(2).childCount - 1)
            selected = 0;
        else
            //jos valitun aseen numero ei mene yli, plussataan yksi valittuun aseen
            selected++;

        //jos entinen ase ei ole valittu
        if (previousWeapon != selected)
            SelectGun();
    }

    void SelectGun()
    {
        //katsotaan jokaisen lapsen l�pi ja asetetaan sen mukaan nykyinen ase katsottuna selected numeroon
        int i = 0;
        foreach(Transform weapon in weaponHolder)
        {
            if (i == selected)
            {
                weapon.gameObject.SetActive(true);
                gun = weapon;
                gunScript = gun.GetComponent<Gun>();
            }
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerDead();
            Destroy(gameObject);
        }
    }

}
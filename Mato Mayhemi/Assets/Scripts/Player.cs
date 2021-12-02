using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GamepadControls gc;

    private float moveHor;
    private float moveVer;
    private Vector2 moveDir;
    public float deadzone;
    public float speed;
    public float force;

    public float jumpVel;
    public float jumps;
    [SerializeField] private float jumpsLeft;

    private Rigidbody2D rb;
    private BoxCollider2D[] bc = new BoxCollider2D[2];

    private Animator anim;

    private SpringJoint2D joint;

    [SerializeField] private LayerMask groundLayerMask;

    private Transform gun;

    private LineRenderer lr;

    private bool rope;
    public float ropeAdjust;

    public LayerMask grappleLayerMask;
    private Vector2 grapplePoint;
    private float distance;

    private int previousWeapon;
    private int selected;

    private float aimHor;
    private float aimVer;

    private float angle;

    private Vector2 aimDir;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();

        gc.Game.Move.performed += ctx => moveHor = ctx.ReadValue<float>();
        gc.Game.Move.canceled += ctx => moveHor = 0;

        gc.Game.AdjustRope.performed += ctx => moveVer = ctx.ReadValue<float>();
        gc.Game.AdjustRope.canceled += ctx => moveVer = 0;

        gc.Game.AimHor.performed += ctx => aimHor = ctx.ReadValue<float>();
        gc.Game.AimVer.performed += ctx => aimVer = ctx.ReadValue<float>();

        gc.Game.Shoot.performed += ctx => Shoot();

        gc.Game.Jump.performed += ctx => Jump();

        gc.Game.Rope.performed += ctx => Rope();

        gc.Game.SwitchWeapon.performed += ctx => SwitchGun();

        lr = GetComponent<LineRenderer>();

        bc = GetComponents<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        joint = GetComponent<SpringJoint2D>();
    }

    //ohjainhommii
    void OnEnable()
    {
        gc.Game.Enable();
    }

    //ohjainhommii
    void OnDisable()
    {
        gc.Game.Disable();
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

    void Update()
    {
        moveDir = new Vector2(moveHor, moveVer);

        if (rb.velocity.y > 0.01)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }

        //jos on liikett�
        if (moveHor != 0)
        {
            //jos et ole ropessa
            if (!joint.enabled)
            {
                if (moveDir.magnitude > deadzone)
                {
                    Move();
                    anim.SetBool("Moving", true);
                }
            }
            //jos olet ropessa
            else
            {
                RopeMove();
                anim.SetBool("Moving", false);
            }
        }
        else
            anim.SetBool("Moving", false);

        //jos tunnistetaan yl�s tai alas liikett� kun ollaan ropessa
        if (moveVer != 0)
        {
            joint.distance -= moveVer * ropeAdjust * Time.deltaTime;
        }

        //lukee floatit ja muuttaa ne vector2
        aimDir = new Vector2(aimHor, aimVer);

        //katsoo onko tikut tarpeeksi kaukana keskelt�
        if (aimDir.magnitude > deadzone)
            Aim();
    }

    void LateUpdate()
    {
        //jos rope on k�yt�ss�, piirret��n rope
        if (rope)
            DrawRope();
    }

    public void Move()
    {
        //t�m� on sit� varten ett� jos tulee ropesta transform.translate ei mene sekasin koska on voimaa rihidbodyssa
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
    }

    void Jump()
    {
        //katsotaan onko meill� hyppyj� j�ljell� ja emme ole ropessa
        if (CheckGround() != 0 && !joint.enabled)
        {
            //lis�t��n voimaa rigidbodyyn
            rb.velocity = Vector2.up * jumpVel;
            jumpsLeft--;

            anim.SetBool("Jumping", true);
        }
    }

    void Rope()
    {
        //jos rope ei ole k�yt�ss�
        if (!rope)
        {
            rope = true;
            lr.enabled = true;

            //disabloidaan pelaajan colliderit frameksi, jotta raycast ei osu omaan pelaajaan
            bc[0].enabled = false;
            bc[1].enabled = false;

            //raycastataan pelaajan kohdasta aseesta yl�sp�in
            RaycastHit2D hit = Physics2D.Raycast(transform.position, gun.up, 100f, grappleLayerMask); //laske jotenkin ilman aseen transformista
            if (hit.collider != null)
            {
                //asetetaan grapplepoint raycastin osumaan kohtaan
                grapplePoint = hit.point;

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
        //jos olemme ropessa, emme k�ytet� transform.translate vain lis�t��n voimaa rigidbodyyn
        Vector2 move = new Vector2(moveHor, 0) * force * Time.deltaTime;
        rb.AddForce(move);
    }

    private float CheckGround()
    {
        //raycastataan laatikko pelaajan alle jotta voimme katsoa koskeeko maata
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc[0].bounds.center, bc[0].bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        if (raycastHit.collider != null)
        {
            //jos koskemme maahan resetataan hypyt
            jumpsLeft = jumps;

            anim.SetBool("Jumping", false);
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
        gun.GetComponent<Gun>().Shoot();
    }

    void SwitchGun()
    {
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
        Transform weaponH = transform.GetChild(2).transform;
        foreach(Transform weapon in weaponH)
        {
            if (i == selected)
            {
                weapon.gameObject.SetActive(true);
                gun = weapon;
            }
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}
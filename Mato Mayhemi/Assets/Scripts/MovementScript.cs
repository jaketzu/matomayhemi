using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    GamepadControls gc;

    private Ninjarope nr;

    private float horizontal;
    private float vertical;
    public float speed;
    public float force;

    public float jumpVel;
    public float jumps;
    [SerializeField]private float jumpsLeft;

    private Rigidbody2D rb;
    private BoxCollider2D[] bc;

    private SpriteRenderer[] bodysr = new SpriteRenderer[2];
    private SpriteRenderer gunsr;
    private Animator anim;

    private SpringJoint2D joint;

    [SerializeField]private LayerMask groundLayerMask;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();

        gc.Game.Move.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.Move.canceled += ctx => horizontal = 0;

        gc.Game.AdjustRope.performed += ctx => vertical = ctx.ReadValue<float>();
        gc.Game.AdjustRope.canceled += ctx => vertical = 0;

        gc.Game.Jump.performed += ctx => Jump();

        nr = transform.GetChild(2).GetComponent<Ninjarope>();

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponents<BoxCollider2D>();

        bodysr[0] = transform.GetChild(0).GetComponent<SpriteRenderer>();
        bodysr[1] = transform.GetChild(1).GetComponent<SpriteRenderer>();
        SwitchGunSR(0);

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
    }

    void Update()
    {
        if(rb.velocity.y > 0.01)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }

        //jos on liikettä
        if (horizontal != 0)
        {
            //jos et ole ropessa
            if (!joint.enabled)
            {
                Move();
                anim.SetBool("Moving", true);
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

        //jos tunnistetaan ylös tai alas liikettä kun ollaan ropessa
        if(vertical != 0)
        {
            nr.ChangeDistance(vertical);
        }
    }

    void Move()
    {
        //tämä on sitä varten että jos tulee ropesta transform.translate ei mene sekasin koska on voimaa rihidbodyssa
        rb.velocity = new Vector2(0, rb.velocity.y);

        //liikesuunta ja nopeus asetetaan
        Vector2 move = new Vector2(horizontal, 0) * speed * Time.deltaTime;
        //siirretään pelaajaa
        transform.Translate(move, Space.World); //hullu

        //animaatiota
        if (horizontal < 0)
        {
            for (int i = 0; i < bodysr.Length; i++)
            {
                bodysr[i].flipX = false;
            }

            gunsr.flipY = true;
        }

        if (horizontal > 0)
        {
            for (int i = 0; i < bodysr.Length; i++)
            {
                bodysr[i].flipX = true;
            }

            gunsr.flipY = false;
        }
    }

    void RopeMove()
    {
        //jos olemme ropessa, emme käytetä transform.translate vain lisätään voimaa rigidbodyyn
        Vector2 move = new Vector2(horizontal, 0) * force * Time.deltaTime;
        rb.AddForce(move);
    }

    void Jump()
    {
        //katsotaan onko meillä hyppyjä jäljellä ja emme ole ropessa
        if(CheckGround() != 0 && !joint.enabled)
        {
            //lisätään voimaa rigidbodyyn
            rb.velocity = Vector2.up * jumpVel;
            jumpsLeft--;

            anim.SetBool("Jumping", true);
        }
    }

    private float CheckGround()
    {
        //raycastataan laatikko pelaajan alle jotta voimme katsoa koskeeko maata
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc[0].bounds.center, bc[0].bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        if(raycastHit.collider != null)
        {
            //jos koskemme maahan resetataan hypyt
            jumpsLeft = jumps;

            anim.SetBool("Jumping", false);
        }
        //palautetaan hyppyjen määrä
        return jumpsLeft;
    }

    public void SwitchGunSR(int gun)
    {
        //asetetaan asespriteksi switchweapon scriptin valitun aseen sprite renderer
        gunsr = transform.GetChild(4).GetChild(gun).GetChild(0).GetComponent<SpriteRenderer>();

        if(GetComponent<SpriteRenderer>().flipX == false)
            gunsr.flipY = false;
    }
}

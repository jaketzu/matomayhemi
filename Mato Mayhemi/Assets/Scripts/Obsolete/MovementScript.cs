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
    private Vector2 dir;
    public float deadzone;
    public float speed;
    public float force;

    public float jumpVel;
    public float jumps;
    [SerializeField]private float jumpsLeft;

    private Rigidbody2D rb;
    private BoxCollider2D[] bc = new BoxCollider2D[2];

    private Animator anim;

    private SpringJoint2D joint;

    [SerializeField]private LayerMask groundLayerMask;

    private Transform gun;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();

        gc.Game.Move.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.Move.canceled += ctx => horizontal = 0;

        gc.Game.AdjustRope.performed += ctx => vertical = ctx.ReadValue<float>();
        gc.Game.AdjustRope.canceled += ctx => vertical = 0;

        gc.Game.Shoot.performed += ctx => Shoot();

        gc.Game.Jump.performed += ctx => Jump();

        nr = transform.GetChild(2).GetComponent<Ninjarope>();

        bc = GetComponents<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        joint = GetComponent<SpringJoint2D>();

        SwitchGun(0);
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
        dir = new Vector2(horizontal, vertical);

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

    public void Move()
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
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void RopeMove()
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

    public void Shoot()
    {
        //gun.;
    }

    public void SwitchGun(int selectedGun)
    {
        gun = transform.GetChild(4).GetChild(selectedGun);
    }
}

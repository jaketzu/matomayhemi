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
    private BoxCollider2D bc;

    private SpringJoint2D joint;

    [SerializeField]private LayerMask groundLayerMask;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.Move.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.Move.canceled += ctx => horizontal = 0;

        gc.Game.AdjustRope.performed += ctx => vertical = ctx.ReadValue<float>();
        gc.Game.AdjustRope.canceled += ctx => vertical = 0;

        gc.Game.Jump.performed += ctx => Jump();
    }

    void OnEnable()
    {
        gc.Game.Enable();
    }

    void OnDisable()
    {
        gc.Game.Disable();
    }

    void Start()
    {
        nr = transform.GetChild(3).GetComponent<Ninjarope>();

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        joint = GetComponent<SpringJoint2D>();

        jumpsLeft = jumps;
    }

    void Update()
    {
        if(horizontal != 0)
        {
            if(!joint.enabled)
                Move();
            else
                RopeMove();
        }

        if(vertical != 0)
        {
            nr.ChangeDistance(vertical);
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        Vector2 move = new Vector2(horizontal, 0) * speed * Time.deltaTime;
        transform.Translate(move, Space.World); //hullu
    }

    void RopeMove()
    {
        Vector2 move = new Vector2(horizontal, 0) * force * Time.deltaTime;
        rb.AddForce(move);
    }

    void Jump()
    {
        if(CheckGround() != 0 && !joint.enabled)
        {
            rb.velocity = Vector2.up * jumpVel;
            jumpsLeft--;
        }
    }

    private float CheckGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        if(raycastHit.collider != null)
            jumpsLeft = jumps;
        return jumpsLeft;
    }
}

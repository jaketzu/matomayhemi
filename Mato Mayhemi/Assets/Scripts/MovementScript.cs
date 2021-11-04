using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    GamepadControls gc;

    private float horizontal;
    public float speed;

    public float jumpVel;
    public float jumps;
    [SerializeField]private float jumpsLeft;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [SerializeField]private LayerMask groundLayerMask;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.Move.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.Move.canceled += ctx => horizontal = 0;

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
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        jumpsLeft = jumps;
    }

    void Update()
    {
        if(horizontal != 0)
        {
            Move();
        }
    }

    void Move()
    {
        Vector2 m = new Vector2(horizontal, 0) * speed * Time.deltaTime;
        transform.Translate(m, Space.World); //hullu
    }

    void Jump()
    {
        if(CheckGround() != 0)
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

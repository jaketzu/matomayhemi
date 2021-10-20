using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float moveDir;
    public float speed;

    public float jumpVel;
    public float jumps;
    [SerializeField]private float jumpsLeft;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [SerializeField]private LayerMask groundLayerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        jumpsLeft = jumps;
    }

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0) //vaiha uuempaan input systeemiin
            Move();

        if(Input.GetKeyDown(KeyCode.UpArrow) && CheckGround() > 0) //vaiha uuempaan input systeemiin
            Jump();
    }

    void Move()
    {
        moveDir = Input.GetAxisRaw("Horizontal"); //vaiha uuempaan input systeemiin
        transform.Translate(Vector3.right * moveDir * speed * Time.deltaTime); //hullu
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpVel;
        jumpsLeft--;
    }

    private float CheckGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        if(raycastHit.collider != null)
            jumpsLeft = jumps;
        return jumpsLeft;

    }
}

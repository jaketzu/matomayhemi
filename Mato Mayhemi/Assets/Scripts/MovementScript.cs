using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float moveDir;
    public float speed;

    public float jumpVel;

    private Rigidbody2D rb;
    private BoxCollider2D bC;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bC = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.UpArrow)) //&& Grounded())
            Jump();

        /*print(Grounded());
        RaycastHit2D raycastHit = Physics2D.BoxCast(bC.bounds.center, bC.bounds.size, 0f, Vector2.down, 0.1f);
        print(raycastHit.collider);*/
    }

    void Move()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * moveDir * speed * Time.deltaTime); //hullu
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpVel;
    }

    private bool Grounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bC.bounds.center, bC.bounds.size, 0f, Vector2.down, 0.1f);
        if(raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

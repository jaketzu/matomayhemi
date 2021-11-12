using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjarope : MonoBehaviour
{
    GamepadControls gc;
    private float horizontal;
    private float vertical;

    private bool rope;
    public float ropeAdjust;

    private Transform player;
    private Transform gun;

    private SpringJoint2D joint;
    
    public LayerMask layerMask;
    private Vector2 grapplePoint;
    private float distance;

    private LineRenderer lr;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.Rope.performed += ctx => Rope();

        gc.Game.AimHor.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.AimVer.performed += ctx => vertical = ctx.ReadValue<float>();
    }

    void OnEnable()
    {
        gc.Enable();
    }

    void OnDisable()
    {
        gc.Disable();
    }

    void Start()
    {
        rope = false;

        player = transform.parent;
        gun = player.GetChild(2);

        joint = player.GetComponent<SpringJoint2D>();
        joint.enabled = false;

        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    void LateUpdate() 
    {
        if(rope)
            DrawRope();
    }

    void Rope()
    {
        if(!rope)
        {
            rope = true;
            lr.enabled = true;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, gun.up, 100f, layerMask); //laske jotenkin ilman aseen transformista
            if(hit.collider != null)
            {
                grapplePoint = hit.point;

                joint.enabled = true;
                joint.connectedAnchor = grapplePoint;
                distance = Vector2.Distance(transform.position, grapplePoint);
                joint.distance = distance;
            }
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
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, grapplePoint);
    }

    public void ChangeDistance(float amount)
    {
        joint.distance -= amount * ropeAdjust * Time.deltaTime;
    } 
}

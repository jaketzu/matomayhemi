using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjarope : MonoBehaviour
{
    GamepadControls gc;

    private bool rope;
    private float horizontal;
    private float vertical;
    private float angle;
    private Quaternion rotQ;
    private float rot;

    public Transform ropePrefab;
    private Transform player;
    private Transform gun;
    private SpringJoint joint;
    public float maxDist;
    public float minDist;
    public float spring;
    public float damper;
    public float massScale;
    private LineRenderer lr;
    private Vector2 grapplePoint;
    public LayerMask layerMask;
    private Transform ropeGO;

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
        lr = GetComponent<LineRenderer>();
    }

    void LateUpdate() 
    {
        DrawRope();
    }

    void Rope()
    {
        if(!rope)
        {
            rope = true;

            angle = Mathf.Atan2(gun.position.y - player.transform.position.y, gun.position.x - player.transform.position.x) * Mathf.Rad2Deg - 90f;
            rotQ = Quaternion.Euler(0, 0, angle);
            rot = rotQ.z;

            RaycastHit2D hit;
            if(Physics2D.Raycast(new Vector2(0,0), transform.up, 100f, layerMask))
            {
                print(hit.point);
                grapplePoint = hit.point;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distance = Vector3.Distance(player.position, grapplePoint);

                joint.maxDistance = distance * maxDist;
                joint.minDistance = distance * minDist;

                joint.spring = spring;
                joint.damper = damper;
                joint.massScale = massScale;

                print(hit.point);
            }

        }
        else
        {
            rope = false;


        }
    }

    void DrawRope()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, grapplePoint);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjarope : MonoBehaviour
{
    GamepadControls gc;

    private bool rope;
    private float horizontal;
    private float vertical;

    public Transform ropePrefab;
    private LineRenderer lr;
    private Vector2 grapplePoint;
    public LayerMask layerMask;
    private Transform ropeGO;


    private float angle;

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
        lr = GetComponent<LineRenderer>();
    }


    void Rope()
    {
        if(!rope)
        {
            rope = true;

            //RaycastHit hit;
            //if(Physics.Raycast(transform.position, ))

            /*ropeGO = Instantiate(ropePrefab, new Vector2(transform.position.x + horizontal, transform.position.y + vertical), transform.rotation);
            ropeGO.position = new Vector2(transform.position.x + horizontal, transform.position.y + vertical);

            angle = Mathf.Atan2(ropeGO.position.y - transform.position.y, ropeGO.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
            ropeGO.eulerAngles = new Vector3(0, 0, angle);*/
        }
        else
        {
            rope = false;

           /*Destroy(ropeGO.gameObject);*/
        }
    }

}

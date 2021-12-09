using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunScript : MonoBehaviour
{
    GamepadControls gc;

    private Transform muzzle;
    private LineRenderer lr;

    private BoxCollider2D[] bc = new BoxCollider2D[2];

    public float time;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();
        gc.Game.Shoot.performed += ctx => Shoot();

        muzzle = transform.GetChild(1);
        lr = transform.GetChild(1).GetComponent<LineRenderer>();

        bc = transform.parent.parent.GetComponents<BoxCollider2D>();
    }

    //ohjainhommii
    void OnEnable()
    {
        gc.Enable();
    }

    //ohjainhommii
    void OnDisable()
    {
        gc.Disable();
    }

    void Start()
    {
        lr.enabled = false;
    }

    void Shoot()
    {
        lr.enabled = true;

        bc[0].enabled = false;
        bc[1].enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, muzzle.up, 1000f);
        StartCoroutine(DrawRope(hit.point));

        if(hit.collider.CompareTag("Player"))
        {
            //takedamage player
        }
        else
        {
            //ympäristö posahus
        }

        bc[0].enabled = true;
        bc[1].enabled = true;      
    }

    private IEnumerator DrawRope(Vector2 hitPoint)
    {
        Vector2 currentPos = new Vector2(muzzle.position.x, muzzle.position.y);
        lr.SetPosition(0, currentPos);
        lr.SetPosition(1, hitPoint);

        yield return new WaitForSeconds(time);

        lr.enabled = false;
    }
}

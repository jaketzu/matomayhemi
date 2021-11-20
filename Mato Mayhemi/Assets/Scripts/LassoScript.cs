using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoScript : MonoBehaviour
{
    GamepadControls gc;

    private Transform player;
    private BoxCollider2D[] bc;

    private Transform gun;
    public float range;
    public float time;
    
    public LayerMask layerMask;

    private LineRenderer lr;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.Lasso.performed += ctx => Lasso();
  
        player = transform.parent;
        bc = player.GetComponents<BoxCollider2D>();
        gun = player.GetChild(2);

        lr = GetComponent<LineRenderer>();
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
        lr.enabled = false;
    }

    void Lasso()
    {
        lr.enabled = true;
        StartCoroutine(DrawRope());

        bc[0].enabled = false;
        bc[1].enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(player.position, gun.up, range, layerMask); //laske jotenkin ilman aseen transformista
        if(hit.collider.CompareTag("Player"))
        {
            //takedamage
            //knockback
        }

        bc[0].enabled = true;
        bc[1].enabled = true;
    }

    private IEnumerator DrawRope()
    {
        Vector2 pos = new Vector2(transform.position.x + gun.position.x, transform.position.y + gun.position.y);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, pos);

        yield return new WaitForSeconds(time);
    }
}

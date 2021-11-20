using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjarope : MonoBehaviour
{
    GamepadControls gc;

    private bool rope;
    public float ropeAdjust;

    private Transform player;
    private BoxCollider2D[] bc = new BoxCollider2D[2];
    
    private Transform gun;

    private SpringJoint2D joint;
    
    public LayerMask layerMask;
    private Vector2 grapplePoint;
    private float distance;

    private LineRenderer lr;

    void Awake()
    {
        //ohjainhommii
        gc = new GamepadControls();

        gc.Game.Rope.performed += ctx => Rope();

        lr = GetComponent<LineRenderer>();

        player = transform.parent;

        joint = player.GetComponent<SpringJoint2D>();

        bc = player.GetComponents<BoxCollider2D>();
        gun = player.GetChild(2);
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
        rope = false;

        joint.enabled = false;

        lr.enabled = false;
    }

    void LateUpdate() 
    {
        //jos rope on käytössä, piirretään rope
        if(rope)
            DrawRope();
    }

    void Rope()
    {
        //jos rope ei ole käytössä
        if(!rope)
        {
            rope = true;
            lr.enabled = true;

            //disabloidaan pelaajan colliderit frameksi, jotta raycast ei osu omaan pelaajaan
            bc[0].enabled = false;
            bc[1].enabled = false;

            //raycastataan pelaajan kohdasta aseesta ylöspäin
            RaycastHit2D hit = Physics2D.Raycast(transform.position, gun.up, 100f, layerMask); //laske jotenkin ilman aseen transformista
            if(hit.collider != null)
            {
                //asetetaan grapplepoint raycastin osumaan kohtaan
                grapplePoint = hit.point;

                //enabloidaan pelaajan springjoint
                joint.enabled = true;
                //yhdistetään springjoint osuttuun seinään
                joint.connectedAnchor = grapplePoint;
                //asetetaan springjointin pituus pelaajan ja grapplepointin väliseksi pituudeksi
                distance = Vector2.Distance(transform.position, grapplePoint);
                joint.distance = distance;
            }

            //enabloidaan pelaajan colliderit
            bc[0].enabled = true;
            bc[1].enabled = true;
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
        //piirretään viiva pelaajasta grapplepointtiin
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, grapplePoint);
    }

    //callataan pelaajan movementscriptistä
    public void ChangeDistance(float amount)
    {
        //asetetaan ropen pituus uudelleen katsoen mihin suuntaan pelaajaa painaa kertaa nopeus
        joint.distance -= amount * ropeAdjust * Time.deltaTime;
    } 
}

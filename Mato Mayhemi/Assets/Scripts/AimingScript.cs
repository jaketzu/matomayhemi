using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingScript : MonoBehaviour
{
    GamepadControls gc;

    private float horizontal;
    private float vertical;

    GameObject lookPoint;
    public float offset;
    Transform player;


    //private Vector2 mousePos;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.AimHor.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.AimVer.performed += ctx => vertical = ctx.ReadValue<float>();

        //gc.Game.AimMouse.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
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
        player = transform.parent.transform;
        lookPoint = player.GetChild(1).gameObject;
    }

    void Update()
    {
        if(horizontal != 0 || vertical != 0)
            Aim();

        //AimMouse();
    }

    void Aim()
    {
        lookPoint.transform.position = new Vector2(player.position.x + horizontal + offset, player.position.y + vertical + offset);
        transform.LookAt(lookPoint.transform.position);
    }

    
    /*void AimMouse()
    {
        //gameObject.transform.LookAt(mousePos);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        print(Camera.main.ScreenToWorldPoint(mousePos));
    }*/
}

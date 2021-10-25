using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingScript : MonoBehaviour
{
    GamepadControls gc;

    private float horizontal;
    private float vertical;

    private Vector2 mousePos;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.AimHor.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.AimVer.performed += ctx => vertical = ctx.ReadValue<float>();

        gc.Game.AimMouse.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
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
        
    }

    void Update()
    {
        if(horizontal != 0 )
            Aim();

        AimMouse();
    }

    void Aim()
    {

    }

    void AimMouse()
    {
        //gameObject.transform.LookAt(mousePos);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        print(Camera.main.ScreenToWorldPoint(mousePos));
    }
}

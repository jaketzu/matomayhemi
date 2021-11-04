using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingScript : MonoBehaviour
{
    GamepadControls gc;

    private float horizontal;
    private float vertical;

    private Transform gun;

    private float angle;


    void Awake()
    {
        gc = new GamepadControls();

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
        gun = transform.GetChild(2);
    }

    void Update()
    {
        if(horizontal != 0 || vertical != 0)
            Aim();
    }

    void Aim()
    {
        gun.position = new Vector2(transform.position.x + horizontal, transform.position.y + vertical);

        angle = Mathf.Atan2(gun.position.y - transform.position.y, gun.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        gun.eulerAngles = new Vector3(0, 0, angle);
    }
}

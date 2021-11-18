using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingScript : MonoBehaviour
{
    GamepadControls gc;

    private float horizontal;
    private float vertical;

    private Vector2 dir;
    public float deadzone;

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
        dir = new Vector2(horizontal, vertical);

        if(dir.magnitude > deadzone)
            Aim();
    }

    void Aim()
    {
        gun.position = new Vector2(transform.position.x + dir.normalized.x, transform.position.y + dir.normalized.y);

        angle = Mathf.Atan2(gun.position.y - transform.position.y, gun.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        gun.eulerAngles = new Vector3(0, 0, angle);
    }
}

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
        //ohjainhommii
        gc = new GamepadControls();

        //siirtää oikean tikun axikset floatteihin
        gc.Game.AimHor.performed += ctx => horizontal = ctx.ReadValue<float>();
        gc.Game.AimVer.performed += ctx => vertical = ctx.ReadValue<float>();

        SwitchGun(0);
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

    void Update()
    {
        //lukee floatit ja muuttaa ne vector2
        dir = new Vector2(horizontal, vertical);

        //katsoo onko tikut tarpeeksi kaukana keskeltä
        if(dir.magnitude > deadzone)
            Aim();
    }

    public void Aim()
    {
        //aseen positio asetetaan verrattuna pelaajaan oikean tikun mukaan
        gun.position = new Vector2(transform.position.x + dir.normalized.x, transform.position.y + dir.normalized.y);

        //aseen rotaatio asetetaan laskemalla pelaajan ja aseen kulman käyttäen tan
        angle = Mathf.Atan2(gun.position.y - transform.position.y, gun.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        gun.eulerAngles = new Vector3(0, 0, angle); //aseen rotaatio asetetaan
    }

    public void SwitchGun(int selectedGun)
    {
        gun = transform.GetChild(4).GetChild(selectedGun);
    }
}

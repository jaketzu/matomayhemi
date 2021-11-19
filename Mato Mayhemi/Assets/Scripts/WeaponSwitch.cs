using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    GamepadControls gc;

    private int previousWeapon;
    [HideInInspector]public int selected;

    void Awake() 
    {
        gc = new GamepadControls();
        gc.Game.SwitchWeapon.performed += ctx => SwitchWeapon();
    }

    void OnEnable()
    {
        gc.Game.Enable();
    }

    void OnDisable()
    {
        gc.Game.Disable();
    }

    void Start()
    {
        selected = 0;

        SelectWeapon();
    }

    void SwitchWeapon()
    {
        previousWeapon = selected;

        if(selected >= transform.childCount - 1)
            selected = 0;
        else
            selected++;

        if(previousWeapon != selected)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selected)
            {
                weapon.gameObject.SetActive(true);
                transform.parent.GetComponent<MovementScript>().SwitchGunSR(selected);
            }

            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}

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
        //ohjainhommii
        gc = new GamepadControls();
        gc.Game.SwitchWeapon.performed += ctx => SwitchWeapon();
    }

    //ohjainhommii
    void OnEnable()
    {
        gc.Game.Enable();
    }

    //ohjainhommii
    void OnDisable()
    {
        gc.Game.Disable();
    }

    void Start()
    {
        //asetetaan valittu ase ensimmäiseksi
        selected = 0;

        SelectWeapon();
    }

    void SwitchWeapon()
    {
        //asetetaan nykyinen ase edelliseksi
        previousWeapon = selected;

        //jos valitun aseen numero menee pelaajan aseiden määrän yli asetetaan valittu ase takaisin ensimmäiseksi
        if(selected >= transform.childCount - 1)
            selected = 0;
        else
            //jos valitun aseen numero ei mene yli, plussataan yksi valittuun aseen
            selected++;

        //jos entinen ase ei ole valittu
        if(previousWeapon != selected)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        //katsotaan jokaisen lapsen läpi ja asetetaan sen mukaan nykyinen ase katsottuna selected numeroon
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selected)
            {
                weapon.gameObject.SetActive(true);
                //callataan pelaajan movementscriptin aseen spriten vaihto funktio
                transform.parent.GetComponent<AimingScript>().SwitchGun(selected);
            }
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}

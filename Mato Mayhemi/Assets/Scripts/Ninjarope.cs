using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjarope : MonoBehaviour
{
    GamepadControls gc;
    private bool rope;
    public GameObject ropeGO;

    void Awake()
    {
        gc = new GamepadControls();

        gc.Game.Rope.performed += ctx => Rope();
    }

    void Start()
    {
        rope = false;
    }

    void OnEnable()
    {
        gc.Enable();
    }

    void OnDisable()
    {
        gc.Disable();
    }

    void Rope()
    {
        if(rope)
        {

        }
        else
        {

        }
    }

}

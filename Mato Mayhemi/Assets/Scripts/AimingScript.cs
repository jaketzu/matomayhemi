using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingScript : MonoBehaviour
{
    GamepadControls gc;

    void Awake()
    {
        gc = new GamepadControls();
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
        
    }
}

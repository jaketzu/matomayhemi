using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    float rand;
    void Start(){
        rand = Random.Range(-10f,10f);
    }
    public void OnPress(){
        print(rand+"Chillisti");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject[] objektit;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 sum = new Vector3(0, 0, 0);
        for (int i = 0; i < objektit.Length; i++)
        {
            sum += objektit[i].transform.position;
        }
        print(sum/objektit.Length);

        transform.position(sum/objektit.Length);
        float dist = Vector3.Distance(objektit[0].transform.position, objektit[1].transform.position);
        print(dist);
    }
}

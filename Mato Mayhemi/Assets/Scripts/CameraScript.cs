using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject[] objektit;
    public float maxZoom;
    public float minZoom;

    float[] distances;
    float longestDistance;

    Vector3 cameraPosition;
    // Update is called once per frame
    void Update()
    {
        CenterCamera();
        CameraZoom();
    }


    void CenterCamera(){
        //lasketaan pelaajien välinen keskikohta
        Vector3 sum = new Vector3(0, 0, 0);
        for (int i = 0; i < objektit.Length; i++)
        {
            sum += objektit[i].transform.position; 
        }
        cameraPosition = new Vector3(sum.x/objektit.Length, sum.y/objektit.Length,-10);
        transform.position = cameraPosition;
        float dist = Vector3.Distance(objektit[0].transform.position, objektit[1].transform.position);
    }
    void CameraZoom(){
        distances = new float[objektit.Length];
        for (int i = 0; i < objektit.Length; i++)
        {
            distances[i] = Vector2.Distance(transform.position, objektit[i].transform.position);
        }
        longestDistance = distances.Max();

        if(minZoom > longestDistance){
            GetComponent<Camera>().orthographicSize = minZoom;
            return;
        }
        GetComponent<Camera>().orthographicSize = longestDistance;
        
    }
}

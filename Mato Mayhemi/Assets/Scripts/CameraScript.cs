using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject[] players;
    public float maxZoom;
    public float minZoom;

    float[] distances;
    float longestDistance;

    Vector3 cameraPosition;


    void Update()
    {   
        players = GameObject.FindGameObjectsWithTag("Player");
        CenterCamera();
        CameraZoom();
    }

    void Awake() 
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }


    void CenterCamera(){
        //lasketaan pelaajien välinen keskikohta
        Vector3 sum = new Vector3(0, 0, 0);
        for (int i = 0; i < players.Length; i++)
        {
            sum += players[i].transform.position; 
        }
        cameraPosition = new Vector3(sum.x/players.Length, sum.y/players.Length,-10);
        transform.position = cameraPosition;
        float dist = Vector3.Distance(players[0].transform.position, players[1].transform.position);
    }
    void CameraZoom(){
        distances = new float[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            distances[i] = Vector2.Distance(transform.position, players[i].transform.position);
        }
        longestDistance = distances.Max();

        if(minZoom > longestDistance){
            GetComponent<Camera>().orthographicSize = minZoom;
            return;
        }
        GetComponent<Camera>().orthographicSize = longestDistance;
        
    }
}

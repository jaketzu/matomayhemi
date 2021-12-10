using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;
    Vector3 cameraPosition;

    private GameObject[] players;


    public float maxZoom;
    public float minZoom;

    float[] distances;
    float longestDistance;

    void Awake() 
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {   
        UpdatePlayerCount();
        
        if(players.Length != 0)
        {
            CenterCamera();
            CameraZoom();
        }
        else
        {
            cam.orthographicSize = 15;
            transform.position = new Vector3(0, 0, -10);
        }
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
    }
    void CameraZoom(){
        distances = new float[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            distances[i] = Vector2.Distance(transform.position, players[i].transform.position);
        }
        longestDistance = distances.Max();

        if(minZoom > longestDistance){
            cam.orthographicSize = minZoom;
            return;
        }
        if(maxZoom < longestDistance){
            cam.orthographicSize = maxZoom;
            return;
        }
        cam.orthographicSize = longestDistance;
        
    }
    public void UpdatePlayerCount(){
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}

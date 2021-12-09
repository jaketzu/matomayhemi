using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] kills;
    private int[] deaths;
    private float timer;
    public float timerDefault;

    //jotenki round based??

    void Start()
    {
        //timer = timerDefault;
    }

    void Update()
    {
        /*timer -= Time.deltaTime;

        if (timer <= 0)
            EndGame();*/
    }

    void EndGame()
    {
        Time.timeScale = 0.25f;
        //laita jotai ui hommii
    }

    public void Kill()
    {
        //++kill p1
        //killfeed
    }
}

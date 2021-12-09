using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] guns;
    private GameObject[] players;

    //private int[] kills;
    //private int[] deaths;
    //private float timer;
    //public float timerDefault;

    //jotenki round based??

    /*void Start()
    {
        timer = timerDefault;
    }*/

    void Awake() 
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for(int pI = 0; pI < players.Length; pI++)
        {
            for(int i = 0; i < 3; i++)
            {
                GameObject gun = guns[Random.Range(0, 6)];
                Instantiate(gun, players[pI].transform.position, Quaternion.identity, players[pI].transform.GetChild(2));
                gun.SetActive(false);
            }
        }
    }

    void Update()
    {
        /*timer -= Time.deltaTime;

        if (timer <= 0)
            EndGame();*/

        if(Keyboard.current.rKey.isPressed)
            SceneManager.LoadScene(Random.Range(1, 3));

        if(Keyboard.current.escapeKey.isPressed)
            SceneManager.LoadScene(0);
    }

    /*void EndGame()
    {
        Time.timeScale = 0.25f;
        laita jotai ui hommii
    }*/

    /*public void Kill()
    {
        //++kill p1
        //killfeed
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] guns;
    private GameObject[] players;

    private int playerAmount;

    private Text text;

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
        players = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
        for(int i = 0; i < players.Length; i++)
        {
            players[i] = GameObject.Find("Player " + (i + 1));
            players[i].SetActive(false);
        }

        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }

    void Update()
    {
        /*timer -= Time.deltaTime;

        if (timer <= 0)
            EndGame();*/

        

        if(Keyboard.current.rKey.isPressed)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings));
        }


        if(Keyboard.current.escapeKey.isPressed)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

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

    public void EnablePlayer()
    {
        int playerNum = GameObject.Find("Input Manager").GetComponent<PlayerInputManager>().playerCount - 1;
        players[playerNum].SetActive(true);

        playerAmount = playerNum + 1;    

        for(int i = 0; i < 3; i++)
        {
            GameObject gun = guns[Random.Range(0, 7)];
            Instantiate(gun, players[playerNum].transform.position, Quaternion.identity, players[playerNum].transform.GetChild(2));
            gun.SetActive(false);
        }
    }

    void AddGun(int num, int gunAmount)
    {
        GameObject gun = guns[Random.Range(0, 7)];

        if(gunAmount == 0)
        {
            Instantiate(gun, players[num].transform.position, Quaternion.identity, players[num].transform.GetChild(2));
            gun.SetActive(false);
        }
        else
        {
            foreach(Transform heldGun in players[num].transform.GetChild(2).transform)
            {
                if(heldGun.name == gun.name)
                {
                    AddGun(num, gunAmount);
                }
                else
                {
                    Instantiate(gun, players[num].transform.position, Quaternion.identity, players[num].transform.GetChild(2));
                    gun.SetActive(false);
                }
            }
        }
    }

    public void PlayerDead()
    {
        playerAmount--;

        if(playerAmount == 1)
        {
            Time.timeScale = 0.25f;
            text.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            text.enabled = false;
        }
    }
}
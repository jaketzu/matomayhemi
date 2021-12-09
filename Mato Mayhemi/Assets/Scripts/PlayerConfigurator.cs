using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerConfigurator : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfs;

    [SerializeField] private int maxPlayers;

    public static PlayerConfigurator Instance  { get; private set; }

    public GameObject[] joinSprites;
    public TextMeshProUGUI[] texts;
    public GameObject[] playerSprites;

    private bool allReady;
    public float timer;

    void Awake() 
    {
        if(Instance = null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfs = new List<PlayerConfiguration>();
        }
    }

    void Start() 
    {
        allReady = false;    
    }

    void Update() 
    {
        if(allReady)
            {
                timer -= Time.deltaTime;
            
                if(timer <= 0)
                    SceneManager.LoadScene("SampleScene");
            }
    }

    public void PlayerJoin(PlayerInput pi)
    {
        if(!playerConfs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);

            playerConfs.Add(new PlayerConfiguration(pi));

            playerConfs[pi.playerIndex].IsReady = true;

            joinSprites[pi.playerIndex].SetActive(false);
            texts[pi.playerIndex].enabled = true;
            playerSprites[pi.playerIndex].SetActive(true);

            if(playerConfs.Count == maxPlayers && playerConfs.All(p => p.IsReady == true))
                allReady = true;
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
        Debug.Log(pi.playerIndex.ToString());
    }

    public PlayerInput Input { get; set; }

    public int PlayerIndex { get; set; }

    public bool IsReady { get; set; }
}
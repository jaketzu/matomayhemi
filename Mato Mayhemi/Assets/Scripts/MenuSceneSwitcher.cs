using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuSceneSwitcher : MonoBehaviour
{   
    public GameObject help;
    public GameObject menu;
    public void SceneSwitch(){
        SceneManager.LoadScene("Digging");
    }
    public void ShowHelp(){
        help.SetActive(true);
        menu.SetActive(false);
    }
    public void HideHelp(){
        help.SetActive(false);
        menu.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuSceneSwitcher : MonoBehaviour
{   
    public bool helpEnabled;
    public GameObject selectionObject;
    public GameObject helpPanel;
    public void SceneSwitch(){
        SceneManager.LoadScene("Digging");
    }

    public void showHelp(){
        helpEnabled = !helpEnabled;
        helpPanel.SetActive(helpEnabled);
    }
    public void showSelected(){
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //selectionObject.SetActive(true);
    }
    public void hideSelection(){
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        //selectionObject.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }

}

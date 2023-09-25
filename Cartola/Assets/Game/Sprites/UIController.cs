using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController gameController;

    public GameObject panelMainMenu, panelGame, panelPause, panelGameover;

    // Start is called before the first frame update

    [System.Obsolete]
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonExit()
    {
        //Forma genérica
        //if(Input.GetButtonDown(KeyCode.Escape))
        //{
        //   Application.Quit();
        //}

        //Forma Android
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.plauer.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void ButtonStartGame()
    {
       
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonPause() 
    {
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
    }

    public void ButtonResume()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
    }

    public void ButtonRestart()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(false);
        gameController.StartGame();
    }

    public void ButtonBackMainMenu()
    {
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        panelGameover.gameObject.SetActive(false);
        gameController.BackMainMenu();
    }
}

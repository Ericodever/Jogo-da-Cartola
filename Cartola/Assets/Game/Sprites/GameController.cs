using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
   [HideInInspector] public int score;

    private int  highscore;

    private float currentTime;

    [SerializeField] private float startTime;

    [HideInInspector] public bool gameStarted;

    private UIController uIController;

    [SerializeField] private Transform player;
    private Vector2 playerPosition;

    private void Awake()
    {
        DeleteHighscore();
    }
    // Start is called before the first frame update
    void Start()
    {
      
        gameStarted = false;
        uIController = FindAnyObjectByType<UIController>(); 
        highscore = GetScore();
        uIController.txtTime.text = currentTime.ToString();
        playerPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SaveScore()
    {   if (score > highscore)
        { 
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        else
        {
            return;
        }
    }

    public int GetScore()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey("highscore");
    }

    public void InvokeCountdownTime()
    {
        InvokeRepeating("CountdownTime", 0f, 1f);
    }

    public void StartGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountdownTime();
        player.position = playerPosition;
    }

    public void BackMainMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountdownTime");
        player.position = playerPosition;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void CountdownTime()
    {
        uIController.txtTime.text = currentTime.ToString();

       if(currentTime > 0f && gameStarted)
        {
            currentTime -= 1f;
            
        }

       else
        {
            uIController.panelGameover.gameObject.SetActive(true);
            uIController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            SaveScore();
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }
    }
}

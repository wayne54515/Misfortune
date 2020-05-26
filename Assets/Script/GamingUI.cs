﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUI : MonoBehaviour
{
    public Text tv_showPlayerName;
    public Text tv_showTime;
    public Text tv_showDistance;
    public GameObject GameOverUI;

    public static int timer;
    public static int distance;
    public GameObject player;

    public Text showPlayerName;
    public Text showTotalDistance;
    public Text showTotalTime;

    private bool isGameOver = false;
    private int noMoveFramesCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        tv_showPlayerName.text = LoginUI.UserName;
        showPlayerName.text = "Name : " + LoginUI.UserName;
        GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( isGameOver ) { return; }

        if ( (int)player.transform.position.z == distance)
        {
            noMoveFramesCount += 1;
        }
        else
        {
            noMoveFramesCount = 0;
        }

        timer = (int)Time.time;
        distance = (int)player.transform.position.z;

        tv_showTime.text = "Time : " + timer.ToString();
        tv_showDistance.text = "Distance : " + distance.ToString();

        if ( noMoveFramesCount > 60)
        {
            ShowGameOver();
            isGameOver = true;
        }

    }

    void ShowGameOver()
    {
        GameOverUI.SetActive(true);
        showTotalTime.text = "Time : " + timer.ToString();
        showTotalDistance.text = "Distance: " + distance.ToString();
    }
}
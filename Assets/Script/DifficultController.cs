using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour
{
    public static float trapRate, obstacleRate, playerSpeed; 
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        if (LoginUI.setting_diffcult.Equals("easy"))
        {
            trapRate = 10;
            obstacleRate = 0;
            playerSpeed = 2.5f;
        }
        else
        {
            trapRate = 50;
            obstacleRate = 70;
            playerSpeed = 4.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            if (trapRate <= 100)
            {
                trapRate += 0.1f;
            }
            if (obstacleRate <= 100)
            {
                obstacleRate += 0.2f;
            }
            //Debug.Log("Trap Rate: "+trapRate);
            time = 0;
        }
    }
}

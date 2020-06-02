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
            obstacleRate = 50;
            playerSpeed = 4.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            if (trapRate < 100)
            {
                trapRate += 0.5f;
            }
            if (obstacleRate < 100)
            {
                obstacleRate += 1f;
            }
            //Debug.Log("Trap Rate: "+trapRate);
            //Debug.Log("Obstacle Rate: " + obstacleRate);
            time = 0;
        }
    }
}

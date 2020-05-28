using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour
{
    public static float trapRate;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        trapRate = LoginUI.setting_diffcult.Equals("easy") ? 10 : 50;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            if (trapRate <= 100)
                trapRate += 0.1f;
            Debug.Log("Trap Rate: "+trapRate);
            time = 0;
        }
    }
}

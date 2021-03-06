﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEffect : MonoBehaviour
{
    private GameObject player,playerMain;
    private PlayerAction playerParent;
    private Rigidbody rb;
    private float trapZ;
    // Start is called before the first frame update
    void Start()
    {
        playerParent = FindObjectOfType<PlayerAction>();
        playerMain = FindObjectOfType<PlayerAction>().gameObject;
        player = FindObjectOfType<PlayerAction>().gameObject.transform.GetChild(0).gameObject;
        rb = player.GetComponent<Rigidbody>();
        trapZ = gameObject.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(trapZ);
        if ((trapZ - playerMain.transform.localPosition.z) < -3)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        float x;
        if(other.name == "PlayerBody")
        {
            x = Random.Range(-1, 2);
            rb.AddForce(6 * x, 5, 0, ForceMode.Impulse);
            if (x != 0)
                playerParent.speed = 0f;
            Debug.Log("hit trap");
        }
    }
}

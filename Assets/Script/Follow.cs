using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject player;
    public static float Timer;
    void Start()
    {
        player = FindObjectOfType<PlayerAction>().gameObject;
    }
    void Update()
    {
        Timer += Time.deltaTime;
        transform.position = new Vector3(player.transform.position.x, -2f, player.transform.position.z);
    }
}

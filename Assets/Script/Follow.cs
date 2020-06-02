using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = FindObjectOfType<PlayerAction>().gameObject.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.9f, player.transform.position.z - 9f);
    }
}

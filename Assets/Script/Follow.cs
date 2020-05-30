using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = FindObjectOfType<PlayerAction>().gameObject;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, -2f, player.transform.position.z);
    }
}

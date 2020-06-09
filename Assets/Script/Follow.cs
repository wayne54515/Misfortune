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
        transform.position = new Vector3(0, 0, player.transform.position.z + 22f);
    }
}

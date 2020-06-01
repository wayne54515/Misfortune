using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private float speed = 0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < 70)
        {
            speed = Random.RandomRange(2.0f, 5.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            if (transform.position != player.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
            }
        }
    }
}

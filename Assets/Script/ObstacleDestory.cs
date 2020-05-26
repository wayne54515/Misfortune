using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestory : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ObstacleDestoryLine")
        {
            Destroy(obstacle);
        }
    }
}

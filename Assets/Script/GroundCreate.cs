using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreate : MonoBehaviour
{
    public GameObject ground;
    private GameObject _ground;
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
        if (other.name == "Player")
        {
            int createpos = (int)ground.transform.localPosition.z;
            //Debug.Log(createpos);
            _ground = Instantiate(ground, new Vector3(0, 0, createpos + 10), Quaternion.identity);
        }
    }
}

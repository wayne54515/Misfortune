using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreate : MonoBehaviour
{
    public GameObject[] ground;
    public GameObject self;
    private GameObject _ground, targetGround;
    private bool isFour = false;
    private int groundNum;
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
        targetGround = ground[Random.Range(0, 4)];
        //targetGround = ground[3];
        if (other.name == "PlayerBody")
        {
            int createpos = (int)self.transform.localPosition.z;
            //Debug.Log(createpos);
            _ground = Instantiate(targetGround, new Vector3(0, 0, createpos + 10), Quaternion.identity);
        }
    }
}

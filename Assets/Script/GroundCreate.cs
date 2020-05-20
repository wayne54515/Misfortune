using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreate : MonoBehaviour
{
    public GameObject[] ground;
    public GameObject self, trap;
    private GameObject _ground, targetGround, _trap;
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
        
        //targetGround = ground[3];
        if (other.name == "PlayerBody")
        {
            targetGround = ground[Random.Range(0, 4)];
            int createpos = (int)self.transform.localPosition.z;
            //Debug.Log(createpos);
            _ground = Instantiate(targetGround, new Vector3(0, 0, createpos + 10), Quaternion.identity);
            _trap = Instantiate(trap, new Vector3(Random.RandomRange(-1.5f, 1.5f), 0.55f, createpos + Random.RandomRange(7.0f, 10.0f)), Quaternion.identity);
        }
    }
}

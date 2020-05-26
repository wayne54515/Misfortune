using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GroundCreate : MonoBehaviour
{
    public GameObject[] ground, obstacle;
    public GameObject self, trap;
    private GameObject _ground, targetGround, _trap, targetObstacle, _obstacle;
    private float a = 0, b = 360;
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

            if (Random.RandomRange(0.0f, 1.0f) < 0.7)
            {
                targetObstacle = obstacle[Random.Range(0, 7)];
                _obstacle = Instantiate(targetObstacle, new Vector3(Random.RandomRange(-1.5f, 1.5f), 0.2f, createpos + Random.RandomRange(7.0f, 10.0f)), new Quaternion(Random.RandomRange(a, b), Random.RandomRange(a, b), Random.RandomRange(a, b), 0));
            }
        }
    }
}

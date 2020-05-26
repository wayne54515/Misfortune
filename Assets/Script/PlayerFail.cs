using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFail : MonoBehaviour
{
    private PlayerAction playerParent;
    // Start is called before the first frame update
    void Start()
    {
        playerParent = FindObjectOfType<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y < -5)
        {
            playerParent.speed = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            playerParent.speed = 0f;
            Debug.Log("child hit");
        }
    }
}

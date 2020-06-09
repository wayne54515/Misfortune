using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFail : MonoBehaviour
{
    private PlayerAction playerParent;
    private GameObject player;
    private Rigidbody rb;
    public bool fail = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerParent = FindObjectOfType<PlayerAction>();
        //player = FindObjectOfType<PlayerAction>().gameObject.transform.GetChild(0).gameObject;
        player = gameObject;
        rb = player.GetComponent<Rigidbody>();
        //Debug.Log(gameObject);
        //Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y < -1)
        {
            fail = true;
            playerParent.speed = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            GameOver();

            Debug.Log("child hit");
        }
    }

    private void GameOver()
    {
        fail = true;
        playerParent.speed = 0f;
        var render = player.GetComponentsInChildren<Renderer>();

        //Debug.Log(mr.Length);
        Color colorStart = Color.white;
        Color colorEnd = Color.clear;
        
        rb.AddForce(0, 0.9f, 0, ForceMode.Impulse);
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        
        foreach (var r in render)
        {
            r.material.color = Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time, 0.7f));
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFail : MonoBehaviour
{
    private PlayerAction playerParent;
    private GameObject player;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerParent = FindObjectOfType<PlayerAction>();
        player = FindObjectOfType<PlayerAction>().gameObject.transform.GetChild(0).gameObject;
        
        rb = player.GetComponent<Rigidbody>();
        //Debug.Log(player_c);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y < -5)
        {
            playerParent.speed = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            playerParent.speed = 0f;
            var render = player.GetComponentsInChildren<Renderer>();
            //Debug.Log(render.Length);
            Color colorStart = Color.white;
            Color colorEnd = Color.clear;
            rb.useGravity = false;
            rb.AddForce(0, 1.2f, 0, ForceMode.Impulse);

            foreach(var r in render)
            {
                r.material.color = Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time, 0.7f));
            }

            Debug.Log("child hit");
        }
    }
}

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
        player = gameObject;
        rb = player.GetComponent<Rigidbody>();
        var material = player.GetComponentInChildren<Renderer>().materials;
        foreach (var m in material)
        {
            m.color = Color.white;
        }
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
        var material = player.GetComponentInChildren<Renderer>().materials;
  
        Debug.Log(player.GetComponentInChildren<Renderer>().materials.Length);

        Color colorStart = Color.white;
        Color colorEnd = Color.clear;
        
        rb.AddForce(0, 0.9f, 0, ForceMode.Impulse);
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        
        foreach (var m in material)
        {
            StartCoroutine(transparency(m));
        }

    }

    private IEnumerator transparency(Material m)
    {
        yield return new WaitForSeconds(0.5f);
        Color colorStart = Color.white;
        Color colorEnd = Color.clear;
        while (m.color.a > 0.15)
        {
            Debug.Log(m.color.a);
            m.color = Color.Lerp(colorStart, colorEnd, Mathf.PingPong(Time.time, 0.9f));
            yield return null;
        }
    }
}

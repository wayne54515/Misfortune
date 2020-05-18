using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animation _anim;
    public float speed = 3.0f;
    private float speedUp = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * speedUp);
        if(speedUp < 5.5f)
            speedUp += 0.0005f;
        //Debug.Log(speedUp);

        //jump
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _anim.Play("jump");
        }
        //quick jump down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _anim.Play("down");
        }
        //go right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //go left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Game Over
        if (collision.gameObject.tag == "Obstacle")
        {
            speed = 0f;
        }
            
    }
}

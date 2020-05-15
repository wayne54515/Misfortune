using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 jump;
    public float jumpForce = 1.0f;
    private bool isGrounded;
    private Rigidbody rb;
    private float speedUp = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * speedUp);
        if(speedUp < 7.8f)
            speedUp += 0.0001f;
        //Debug.Log(speedUp);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * (speed-2) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * (speed-1) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (isGrounded && (Input.GetKey(KeyCode.Z)))
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Game Over
        if (collision.gameObject.tag == "Obstacle")
            speed = 0f;
    }
}

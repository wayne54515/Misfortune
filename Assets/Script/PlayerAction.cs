using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animation _anim;
    private AudioSource audio;
    public float speed = DifficultController.playerSpeed;
    private float speedUp = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * speedUp);
        if(speedUp < 6.0f)
        {
            speedUp += 0.0005f;
            _anim["jump"].speed += 0.0002f;
            audio.pitch += 0.0001f;
        }
            
        //Debug.Log(speedUp);

        //jump
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _anim.Play("jump");
        }
        //quick jump down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //if(!_anim.isPlaying)
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
}

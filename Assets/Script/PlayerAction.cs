using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animation _anim;
    private AudioSource audio;
    public float speed = DifficultController.playerSpeed;
    private float speedUp = 1.0f, D;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        D = (0.8f + speedUp / 5);       //D在1~2之間遞增
        transform.Translate(Vector3.forward * speed * Time.deltaTime * speedUp);
        if(speedUp < 6.0f)
        {
            speedUp += 0.0005f;
            _anim["jump"].speed += 0.0002f;
            audio.pitch = 1 + 0.001f * speedUp;
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
            transform.Translate(Vector3.right * speed * Time.deltaTime * D);
        }
        //go left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * D);
        }

    }
}

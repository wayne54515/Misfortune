using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animation _anim;
    private AudioSource audio;
    public float speed = DifficultController.playerSpeed;
    private float speedUp = 1.0f, D;
    private bool isFail;
    private GameObject playerBody;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        isFail = FindObjectOfType<PlayerFail>().fail;
        playerBody = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        D = (0.8f + speedUp / 5);       //D在1~2之間遞增
        transform.Translate(Vector3.forward * speed * Time.deltaTime * speedUp);
        if(speedUp < 6.0f)
        {
            //Debug.Log(speedUp);
            speedUp += 0.0005f;
            _anim["jump"].speed += 0.0002f;
            audio.pitch = 1 + 0.001f * speedUp;
        }

        //Debug.Log(LoginUI.setting_diffcult);
        isFail = FindObjectOfType<PlayerFail>().fail;

        //gravity on/off
        if (Input.GetKey(KeyCode.N) & Input.GetKey(KeyCode.G) & !isFail)
        {
            playerBody.GetComponent<Rigidbody>().useGravity = false;
        }
        if (Input.GetKey(KeyCode.H) & Input.GetKey(KeyCode.G) & !isFail)
        {
            playerBody.GetComponent<Rigidbody>().useGravity = true;
        }

        if (LoginUI.setting_diffcult.Equals("easy") & !isFail)
        {
            //jump
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _anim.Play("jump");
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
        if (LoginUI.setting_diffcult.Equals("diffcult") & !isFail)
        {
            //jump
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _anim.Play("jump");
            }
            //go right
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime * D);
            }
            //go left
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime * D);
            }
        }

    }
}

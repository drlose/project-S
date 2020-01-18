using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager; // gamemanagerLogic 클래스를 manager에 담음
    bool isJump;
    Rigidbody rigid;
    public new AudioSource audio;


    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {

            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount); // manager  할당받은 객체에 script를 넣어주지 않으면 NullReferenceException 오류남 확인할것

        }

        else if (other.tag == "Point")
        {
            SceneManager.LoadScene(0);
        }

        else if (other.tag == "Next")
        {

            if (itemCount >= manager.totalItemCount)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        else if (other.tag == "Last")
        {

            if (itemCount >= manager.totalItemCount)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }



        else if (other.tag == "Re")
        {

            if (itemCount >= manager.totalItemCount)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }


    }
}



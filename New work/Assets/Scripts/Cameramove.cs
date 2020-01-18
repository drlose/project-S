using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position; // 설정해둔 카메라와 플레이어간의 거리
    }

    void Update()
    {
        transform.position = playerTransform.position + offset;
        


    }
}

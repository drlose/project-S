using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorMove : MonoBehaviour
{
    public float startTime;
    public float minX, maxX;
    public float moveSpeed;
    private int sign = -1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >=startTime)
        {
            //설정된 min,max 까지 이동반복
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);

            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }

 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        //제자리 회전  space.World (회전축 글로벌)
        transform.Rotate(new Vector3(0,1,0) * rotateSpeed * Time.deltaTime,Space.World);
    }

  
}

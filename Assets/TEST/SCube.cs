using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCube : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine ( MoveRRRR());
    }

    private IEnumerator MoveRRRR()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("2초후 작은 박스위치로 이동");
            yield return new WaitForSeconds(2.0f); // 다음 로직을 시간만큼 기다림 (float) 
            this.transform.position = (new Vector3(1, 1, -1)); // this는 스크립트가 들어있는 작은박스의 초기값
            GameObject player = GameObject.Find("unitychan") as GameObject;  // "unitychan" 이름을 찾아서 "player" 라는 변수에 담고 오브젝트로써 사용
            player.transform.position = this.transform.position;

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject child = GameObject.Find("Box") as GameObject;
            Debug.Log("작은큐브가 3초간 캐릭터를 따라다님");
            child.transform.parent = this.transform.parent;

            yield return new WaitForSeconds(3.0f);
            Debug.Log("3초후 객체분리");
            child.transform.parent = null;

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class MainController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigid;
    private BoxCollider col;

    public float moveSpeed;
    public float jumpForce;

    private bool isMove;
    private bool isJump;

    NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        TryWalk();
        StartCoroutine ( TryJump());

        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 클릭
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                // 레이캐스트 성공시, 즉 눌렀을 때 내비매쉬에 클릭 됐을 때
                agent.SetDestination(hit.point);


          
                anim.Play("MOVE",-1, 3f);


            }

        }


    }

    private IEnumerator TryJump() // 코루틴 짱짱맨.. 
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            anim.SetTrigger("Jump");
            isJump = true;
            // this.transform.position = new Vector3(0, jumpForce, 0); 포지션 이동, Vector3 (x,y,z)
            rigid.velocity = new Vector3(0, jumpForce + 0.01f, 0);


            yield return new WaitForSeconds(1.15f); // 다음 로직을 시간만큼 기다림 (float) 
            isJump = false;
            Debug.Log("이제 점프가능");


        }

    }

    private void TryWalk()
    {
        float _dirX = Input.GetAxisRaw("Horizontal");
        float _dirZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(_dirX, 0, _dirZ);
        isMove = false;

        if (direction != Vector3.zero)
        {
            isMove = true;
            this.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

        }

        anim.SetBool("Move", isMove);
        anim.SetFloat("DirX", direction.x);
        anim.SetFloat("DirZ", direction.z);

    }

    /*
    private void OnCollisionEnter(Collision collision) // 콜리전에 닿으면
    {
        if (collision.gameObject.tag == "Floor") // 닿은 콜리전의 태그가 Floor 면
           isJump = false;
           Debug.Log(collision.gameObject.tag);
           Debug.Log(isJump);
        
     }     
   
    */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_BallJump : MonoBehaviour
{

    [SerializeField] bool isFloored;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] Rigidbody ballRigidbody;


    void Start()
    {
        isFloored = true;
        //Rigidbody 컴포넌트를 현재 게임 오브젝트에서 가져옴
        //드래그앤드롭하지 않아도 알아서 가져와짐
        ballRigidbody = GetComponent<Rigidbody>();


    }

    void FixedUpdate()
    {
        // 스페이스바를 누르면 물리적인 힘에 의해 점프함
        if (Input.GetKeyDown(KeyCode.Space) && isFloored == true)
        {
            ballRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            isFloored = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //점프를 한 번만 할 수 있도록 제어
        //바닥에 닿았을 때만 isFloored를 true
        //collision.contacts[0]: https://velog.io/@ocx/Collision%EA%B3%BC-Contacts 참고
        //contacts[0]은 충돌한 바닥의 첫 번째 접촉 지점
        if (collision.contacts[0].normal == Vector3.up)
        {
            isFloored = true;
        }
    }

}

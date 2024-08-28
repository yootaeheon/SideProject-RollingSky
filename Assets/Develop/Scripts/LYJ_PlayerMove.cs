using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- 클래스 내부 필드 ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] bool isFloored;         //바닥에 닿았는지 여부.  T 닿음,  F 떨어짐
    [SerializeField] Vector3 startPosition;  //플레이어의 처음 위치



    //-----------------------------------------------------
    //----------------- 유니티 메시지 함수 -----------------
    //----------------------------------------------------

    void Start()
    {
        isFloored = true;
        startPosition = transform.position;

    }


    void Update()
    {

        //만약 공의 y방향 값이 -5 이하이면 위치 초기화
        if (transform.position.y <= -5)
        {
            ResetPosition();
        }

        // F키를 누르고 있는 동안에는 그대로 멈춰있음
        if (Input.GetKey(KeyCode.F))
        {
            transform.position += Vector3.zero;
            return;

        }

        // 가만히 있어도 항상 앞으로 굴러감
        transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
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


    //-----------------------------------------------------
    //------------------ 개인 커스텀 함수 ------------------
    //----------------------------------------------------

    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    public void Die()
    {

    }

}

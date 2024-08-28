using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- 클래스 내부 필드 ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] Vector3 startPosition;  //플레이어의 처음 위치

    [SerializeField] Transform playerTransform;

    //-----------------------------------------------------
    //----------------- 유니티 메시지 함수 -----------------
    //----------------------------------------------------

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {

        //만약 공의 y방향 값이 -5 이하이면 위치 초기화
        if (playerTransform.position.y <= -5)
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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }


    }



    //-----------------------------------------------------
    //------------------ 개인 커스텀 함수 ------------------
    //----------------------------------------------------

    private void ResetPosition()
    {
        transform.position = startPosition;
        playerTransform.position = startPosition;
    }

    public void Die()
    {
        //BSM_TrapCube에서 링크됨
    }

}

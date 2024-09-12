using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- 클래스 내부 필드 ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] float SpeedBoost; //부스트 속도 증가량

    [SerializeField] float SpeedBoostTime; //속도 증가 지속 시간

    [SerializeField] Vector3 startPosition;  //플레이어의 처음 위치

    [SerializeField] Transform playerTransform;

    private bool isSpeedBoosted = false; //현재 부스트가 적용 중인가?
    private float originalMoveSpeed; //부스트 적용 전 (원래 이동 속도)를 저장

    //-----------------------------------------------------
    //----------------- 유니티 메시지 함수 -----------------
    //----------------------------------------------------

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        originalMoveSpeed = MoveSpeed; //처음엔 원래 이동 속도 저장하여 사용
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

        //isSpeedBoosted가 true이면 MoveSpeed에 SpeedBoost 곱한 속도로 이동, false이면 기본 속도로 이동
        float currentSpeed = isSpeedBoosted ? MoveSpeed * SpeedBoost : MoveSpeed;
        
        //앞으로 계속 공을 굴림
        transform.position += Vector3.forward * currentSpeed * Time.deltaTime;

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

    //속도 부스터 적용하는 함수
    public void ApplySpeedBoost()
    {
        //속도 부스트가 적용되어 있지 않은 상태면
        if (!isSpeedBoosted)
        {
            //코루틴 시작
            StartCoroutine(SpeedBoostCoroutine());
        }
    }

    //정해진 시간 동안 속도 부스트를 적용하는 코루틴
    private IEnumerator SpeedBoostCoroutine()
    {
        //시작하면 부스트 상태를 true로 설정하고
        isSpeedBoosted = true;

        //지정한 SpeedBoostTime만큼 적용되었다가
        yield return new WaitForSeconds(SpeedBoostTime);
        
        //부스트 상태를 다시 false로 설정
        isSpeedBoosted = false;
    }

}

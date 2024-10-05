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

    private bool isReversed = false;  //좌우 이동 반전 상태를 저장

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
        
        //앞으로 계속 공을 굴림
        transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (isReversed)
                transform.position += Vector3.right * MoveSpeed * Time.deltaTime; //방향 반전
            else
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (isReversed)
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime; //방향 반전
            else
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


    //좌우 반전을 설정하는 함수 추가
    public void ReverseControls(bool reverse)
    {
        isReversed = reverse;
    }

    //이동 속도 설정 함수
    public void SetMoveSpeed(float newSpeed)
    {
        MoveSpeed = newSpeed;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }

    //쉴드 효과를 적용하는 코루틴
    public IEnumerator ActivateShield()
    {
        Renderer playerRenderer = GetComponent<Renderer>();

        if (playerRenderer != null)
        {
            Color originalColor = playerRenderer.material.color;

            //플레이어를 반투명하게 변경
            playerRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.4f);
            Debug.Log("쉴드 효과 적용");

            //5초 대기
            yield return new WaitForSeconds(5f);

            //원래 색상으로 복원
            playerRenderer.material.color = originalColor;
            Debug.Log("쉴드 효과 해제");
        }
    }
}

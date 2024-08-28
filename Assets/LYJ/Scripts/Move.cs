using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;

    private bool isFloored = true; //바닥에 있는지

    private Vector3 startPosition; //플레이어의 처음 위치

    private void Start()
    {
        //Rigidbody 컴포넌트를 현재 게임 오브젝트에서 가져옴
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);

        // 움직임
        if (moveDir != Vector3.zero)
        {
            transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }

        // 점프
        if (isFloored && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFloored = false; // 점프 후에는 지면에서 떨어짐
        }

        //만약 공의 y방향 값이 -5 이하이면 위치 초기화
        if(transform.position.y <= -5)
        {
            ResetPosition();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 바닥에 닿았을 때만 isFloored를 true
        //collision.contacts[0]: https://velog.io/@ocx/Collision%EA%B3%BC-Contacts 참고
        //contacts[0]은 충돌한 바닥의 첫 번째 접촉 지점
        if (collision.contacts[0].normal == Vector3.up)
        {
            isFloored = true;
        }
    }
    private void ResetPosition()
    {
        transform.position = startPosition;
    }
}

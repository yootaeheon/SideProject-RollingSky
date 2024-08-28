using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
public class Test_Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed; //움직임속도
    [SerializeField] float jumpForce; //점프할 때 드는 힘
    [SerializeField] Rigidbody rb;
    private bool isFloored = true; //바닥에 있는지
    private Vector3 startPosition; //플레이어의 처음 위치
    private void Start()
    {
        //Rigidbody 컴포넌트를 현재 게임 오브젝트에서 가져옴
        //드래그앤드롭하지 않아도 알아서 가져와짐
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }
    private void Update()
    {
        //자동으로 앞으로 감
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 moveDir = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);
        rb.velocity = moveDir;
        // 점프
        if (isFloored && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFloored = false; // 점프 후에는 지면에서 떨어짐
        }
        //만약 공의 y방향 값이 -5 이하이면 위치 초기화
        if (transform.position.y <= -5)
        {
            ResetPosition();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //점프를 한 번만 할 수 있도록 제어
        //바닥에 닿았을 때만 isFloored를 true
        //collision.contacts[0]:
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

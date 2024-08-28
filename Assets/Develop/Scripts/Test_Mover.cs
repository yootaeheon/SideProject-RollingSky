using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
public class Test_Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed; //�����Ӽӵ�
    [SerializeField] float jumpForce; //������ �� ��� ��
    [SerializeField] Rigidbody rb;
    private bool isFloored = true; //�ٴڿ� �ִ���
    private Vector3 startPosition; //�÷��̾��� ó�� ��ġ
    private void Start()
    {
        //Rigidbody ������Ʈ�� ���� ���� ������Ʈ���� ������
        //�巡�׾ص������ �ʾƵ� �˾Ƽ� ��������
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }
    private void Update()
    {
        //�ڵ����� ������ ��
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 moveDir = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);
        rb.velocity = moveDir;
        // ����
        if (isFloored && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFloored = false; // ���� �Ŀ��� ���鿡�� ������
        }
        //���� ���� y���� ���� -5 �����̸� ��ġ �ʱ�ȭ
        if (transform.position.y <= -5)
        {
            ResetPosition();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //������ �� ���� �� �� �ֵ��� ����
        //�ٴڿ� ����� ���� isFloored�� true
        //collision.contacts[0]:
        //contacts[0]�� �浹�� �ٴ��� ù ��° ���� ����
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

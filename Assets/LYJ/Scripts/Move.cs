using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;

    private bool isFloored = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);

        // ������
        if (moveDir != Vector3.zero)
        {
            transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }

        // ����
        if (isFloored && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isFloored = false; // ���� �Ŀ��� ���鿡�� ������
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ٴڿ� ����� ���� isFloored�� true
        //collision.contacts[0]: https://velog.io/@ocx/Collision%EA%B3%BC-Contacts ����
        //contacts[0]�� �浹�� �ٴ��� ù ��° ���� ����
        if (collision.contacts[0].normal == Vector3.up)
        {
            isFloored = true;
        }
    }
}
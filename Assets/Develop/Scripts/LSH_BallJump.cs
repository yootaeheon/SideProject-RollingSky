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
        //Rigidbody ������Ʈ�� ���� ���� ������Ʈ���� ������
        //�巡�׾ص������ �ʾƵ� �˾Ƽ� ��������
        ballRigidbody = GetComponent<Rigidbody>();


    }

    void FixedUpdate()
    {
        // �����̽��ٸ� ������ �������� ���� ���� ������
        if (Input.GetKeyDown(KeyCode.Space) && isFloored == true)
        {
            ballRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            isFloored = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //������ �� ���� �� �� �ֵ��� ����
        //�ٴڿ� ����� ���� isFloored�� true
        //collision.contacts[0]: https://velog.io/@ocx/Collision%EA%B3%BC-Contacts ����
        //contacts[0]�� �浹�� �ٴ��� ù ��° ���� ����
        if (collision.contacts[0].normal == Vector3.up)
        {
            isFloored = true;
        }
    }

}

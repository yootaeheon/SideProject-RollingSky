using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- Ŭ���� ���� �ʵ� ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] bool isFloored;         //�ٴڿ� ��Ҵ��� ����.  T ����,  F ������
    [SerializeField] Vector3 startPosition;  //�÷��̾��� ó�� ��ġ



    //-----------------------------------------------------
    //----------------- ����Ƽ �޽��� �Լ� -----------------
    //----------------------------------------------------

    void Start()
    {
        isFloored = true;
        startPosition = transform.position;

    }


    void Update()
    {

        //���� ���� y���� ���� -5 �����̸� ��ġ �ʱ�ȭ
        if (transform.position.y <= -5)
        {
            ResetPosition();
        }

        // FŰ�� ������ �ִ� ���ȿ��� �״�� ��������
        if (Input.GetKey(KeyCode.F))
        {
            transform.position += Vector3.zero;
            return;

        }

        // ������ �־ �׻� ������ ������
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
        //������ �� ���� �� �� �ֵ��� ����
        //�ٴڿ� ����� ���� isFloored�� true
        //collision.contacts[0]: https://velog.io/@ocx/Collision%EA%B3%BC-Contacts ����
        //contacts[0]�� �浹�� �ٴ��� ù ��° ���� ����
        if (collision.contacts[0].normal == Vector3.up)
        {
            isFloored = true;
        }
    }


    //-----------------------------------------------------
    //------------------ ���� Ŀ���� �Լ� ------------------
    //----------------------------------------------------

    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    public void Die()
    {

    }

}

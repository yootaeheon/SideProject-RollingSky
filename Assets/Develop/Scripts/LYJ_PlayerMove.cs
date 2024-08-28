using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- Ŭ���� ���� �ʵ� ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] Vector3 startPosition;  //�÷��̾��� ó�� ��ġ

    [SerializeField] Transform playerTransform;

    //-----------------------------------------------------
    //----------------- ����Ƽ �޽��� �Լ� -----------------
    //----------------------------------------------------

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {

        //���� ���� y���� ���� -5 �����̸� ��ġ �ʱ�ȭ
        if (playerTransform.position.y <= -5)
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
    //------------------ ���� Ŀ���� �Լ� ------------------
    //----------------------------------------------------

    private void ResetPosition()
    {
        transform.position = startPosition;
        playerTransform.position = startPosition;
    }

    public void Die()
    {
        //BSM_TrapCube���� ��ũ��
    }

}

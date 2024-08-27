using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_PlayerMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    void Update()
    {

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



}

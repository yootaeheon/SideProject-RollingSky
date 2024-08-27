using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_PlayerMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    void Update()
    {

        // F키를 누르고 있는 동안에는 그대로 멈춰있음
        if (Input.GetKey(KeyCode.F))
        {
            transform.position += Vector3.zero;
            return;

        }

        // 가만히 있어도 항상 앞으로 굴러감
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

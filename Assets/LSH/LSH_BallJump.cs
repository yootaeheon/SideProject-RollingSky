using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_BallJump : MonoBehaviour
{

    [SerializeField] float jumpPower;
    [SerializeField] Rigidbody ballRigidbody;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        // �����̽��ٸ� ������ �������� ���� ���� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);

        }


    }


}

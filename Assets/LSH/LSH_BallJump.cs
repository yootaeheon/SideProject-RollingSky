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
        // 스페이스바를 누르면 물리적인 힘에 의해 점프함
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);

        }


    }


}

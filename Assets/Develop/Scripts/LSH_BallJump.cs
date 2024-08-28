using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_BallJump : MonoBehaviour
{

    [SerializeField] float jumpPower;
    [SerializeField] Rigidbody ballRigidbody;

    void Start()
    {

        //Rigidbody 컴포넌트를 현재 게임 오브젝트에서 가져옴
        //드래그앤드롭하지 않아도 알아서 가져와짐
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

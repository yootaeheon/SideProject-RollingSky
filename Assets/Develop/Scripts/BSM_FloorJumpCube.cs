using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorJumpCube : MonoBehaviour
{

    [SerializeField] private LYJ_PlayerMove player;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpAngle;

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            rb = collision.gameObject.GetComponent<Rigidbody>();

            //포물선으로 떨어지게 수정 필요

            float angle = jumpAngle * Mathf.Rad2Deg; 
            Vector3 force = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0 ) * jumpPower;

            rb.AddForce(force, ForceMode.Impulse);
            rb.velocity = Vector3.zero;
            

        }

    }
 

   



}

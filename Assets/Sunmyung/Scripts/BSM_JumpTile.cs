using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSM_JumpTile : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    Rigidbody playerRB;

     
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerRB = collision.gameObject.GetComponent<Rigidbody>();
            playerRB.AddForce(Vector3.up * jumpPower , ForceMode.Impulse);
        }
        
    } 
}

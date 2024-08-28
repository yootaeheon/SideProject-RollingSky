using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float forwardSpeed;

    private bool life = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
     
        //공이 살아있을 때에만 움직임
        if (life)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            Move(); 
        }

        if(transform.position.y < 0)
        { 
            life = false; 
        }
 
    }


    public void Move()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
         
        Vector3 normal = new Vector3(xPos, 0, 0);
        normal.Normalize();

        rb.velocity = normal * moveSpeed;

         
    }
 

    public void Die()
    {
        life = false;
    }


}

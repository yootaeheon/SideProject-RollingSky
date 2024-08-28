using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCube : MonoBehaviour
{

    [SerializeField] private PlayerMove player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            player.Die();
        }
         
    }




}

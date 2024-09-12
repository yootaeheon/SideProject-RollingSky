using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BumperTrap : MonoBehaviour
{

    [Header("Ray Distance")]
    [SerializeField] private float distance;

    
    private Transform player;
    private Animator animator;

    private BumperTriggerCheck playerCheck;
    private bool isCheck;
    private void Awake()
    {
  
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCheck = GetComponentInChildren<BumperTriggerCheck>();
    }


    void Update()
    {
        PlayerWatch();
    }


    public void PlayerWatch()
    { 
        isCheck = playerCheck.PlayerCheck();
        
        animator.SetBool("isCheck", isCheck); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //게임 종료
            Debug.Log("플레이어 사망");
        }
    }

 
}

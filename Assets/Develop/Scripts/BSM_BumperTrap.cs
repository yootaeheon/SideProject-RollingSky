using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BSM_BumperTrap : MonoBehaviour
{

    [Header("Ray Distance")]
    [SerializeField] private float distance;

    
    private Transform player;
    private Animator animator;

    private BSM_BumperTriggerCheck playerCheck;
    private bool isCheck;
    private void Awake()
    {
  
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCheck = GetComponentInChildren<BSM_BumperTriggerCheck>();
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
            //���� ����
            Debug.Log("�÷��̾� ���");
        }
    }

 
}

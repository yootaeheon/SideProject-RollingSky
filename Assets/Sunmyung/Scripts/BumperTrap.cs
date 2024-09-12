using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BumperTrap : MonoBehaviour
{
    
    [Header("Trap Transform")]
    [SerializeField] private Transform bumperOne;
    [SerializeField] private Transform bumperTwo;
    [SerializeField] private Transform bumperThree;

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
            //���� ����
            Debug.Log("�÷��̾� ���");
        }
    }

 
}

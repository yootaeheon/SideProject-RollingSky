using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSM_MoveTrap : MonoBehaviour
{

    public enum Dir { Left, Right, Forward, Back }
    [SerializeField] public Dir curDir; 
    [SerializeField] private Transform parent;
    [SerializeField] private float moveSpeed;

    [Header("이동 블록 움직이는 시간")]
    [SerializeField] private float stopTime;

    private bool isStop;

    private Coroutine moveRoutine;
    private Vector3 dirVector;

    private void Awake()
    {
        switch (curDir)
        {
            case Dir.Left:
                dirVector = Vector3.left;
                break;

            case Dir.Right:

                dirVector = Vector3.right;
                break;

            case Dir.Forward:
                dirVector = Vector3.forward;
                break;
            case Dir.Back:
                dirVector = Vector3.back;
                break;

        } 
    }


    private void Update()
    {
        if (isStop && moveRoutine == null)
        {
            moveRoutine = StartCoroutine(MoveCoroutine());
        }


        if (moveRoutine != null && !isStop)
        {
            StopCoroutine(moveRoutine); 
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStop = true; 
        }

    }



  
    public IEnumerator MoveCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < stopTime)
        {
            elapsedTime += Time.deltaTime; 

            parent.transform.Translate(dirVector * moveSpeed * Time.deltaTime);

            yield return null; 
        }

        isStop = false;
        yield break;
    }


}

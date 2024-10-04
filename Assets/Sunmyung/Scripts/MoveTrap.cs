using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{

    public enum Dir { Left, Right, Forward, Back }
    [SerializeField] public Dir curDir; 
    [SerializeField] private Transform parent;
    [SerializeField] private float moveSpeed;

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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStop = false;
            moveRoutine = StartCoroutine(MoveCoroutine());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStop = true;

            if (moveRoutine != null)
            {
                StopCoroutine(MoveCoroutine());
            }

        }

    }



    public IEnumerator MoveCoroutine()
    {
        while (!isStop)
        {
            parent.transform.Translate(dirVector * moveSpeed * Time.deltaTime);

            yield return null;
        }

    }


}

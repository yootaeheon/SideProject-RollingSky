using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTrap : MonoBehaviour
{
    private Transform player;

    private Coroutine watch;
    private WaitForSeconds watchWait;
    private bool isGrowth = false;

    private void Awake()
    {
        watchWait = new WaitForSeconds(0.5f);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        PlayerWatch(); 
    }

    public void PlayerWatch()
    {
        Debug.DrawRay(transform.position, player.position * 5f, Color.red);

        if (Physics.Raycast(transform.position, player.position, out RaycastHit hit, 5f))
        {
            if(hit.collider.tag == "Player")
            {
                watch = StartCoroutine(ScaleCoroutine());
            }
        }

        if (watch != null && isGrowth)
        {
            StopCoroutine(watch);
            watch = null;

        }

    }


    public IEnumerator ScaleCoroutine()
    {
        //가장 안쪽 블록 상승
        yield return watchWait;

        //두 번째 블록 상승
        yield return watchWait;

        //세 번째 블록 상승 
        isGrowth = true;
    }

}

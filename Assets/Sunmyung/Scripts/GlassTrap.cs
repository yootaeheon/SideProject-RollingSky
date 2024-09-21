using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTrap : MonoBehaviour
{

    private Coroutine timer;
    private WaitForSeconds wait;
    private Rigidbody rb;

    private void Awake()
    {
        wait = new WaitForSeconds(30f);
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timer = StartCoroutine(TimerCoroutine());
        }
    }
 

    public IEnumerator TimerCoroutine()
    { 
        yield return wait;
        rb.useGravity = true;

        yield return wait;
        Destroy(gameObject);

    }

}

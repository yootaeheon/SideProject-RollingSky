using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BSM_GlassTrap : MonoBehaviour
{
    [Header("Rigidbody Drag")]
    [SerializeField] float drag; 

    private Coroutine timer;
    private WaitForSeconds wait;
    private Rigidbody rb;

    private void Awake()
    {
        wait = new WaitForSeconds(1.5f);
        rb = GetComponent<Rigidbody>();

        rb.drag = drag; 
    }

    private void OnDestroy()
    {
        if(timer != null)
        {
            StopCoroutine(timer);
        }
        
    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timer = StartCoroutine(TimerCoroutine());
        }
    }
 

    public IEnumerator TimerCoroutine()
    {
        rb.constraints = RigidbodyConstraints.None;
        yield return wait;

        
        Destroy(gameObject);

    }

}

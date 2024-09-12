using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperTriggerCheck : MonoBehaviour
{
    private bool isCheck;
     
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            isCheck = true;
        }
        else
        {
            isCheck = false;
        }

    }

    public bool PlayerCheck()
    {
        return isCheck;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrap : MonoBehaviour
{
    [SerializeField] private Transform hammerRotate;
    [SerializeField] private float rotSpeed;

    private void Update()
    {
        HammerSpin();
    }


    public void HammerSpin()
    {
        //망치 회전
        hammerRotate.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
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

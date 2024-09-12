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
        //��ġ ȸ��
        hammerRotate.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
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

using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AirTrap : MonoBehaviour
{
    [Header("Propeller")]
    [SerializeField] private Transform propeller;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private float waitingTime;

    private Rigidbody rb;
    private Coroutine fly;
    private WaitForSeconds flyWait;

    private float propellerSpeed;
    private float startHeight;
    private float maxHeight = 2f;
    private float curHeight;
    private float accel;

    private bool isFlying = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.useGravity = false;
        flyWait = new WaitForSeconds(waitingTime);

        //���� ����
        startHeight = transform.position.y; 
    }
 
    private void Update()
    {

        PropellerRotate();
        TakeOff();
        Landing();

    }

    public void PropellerRotate()
    {
        if (isFlying)
        {
            //�����緯 ���� �������� ȸ��
            propellerSpeed += rotateSpeed * Time.deltaTime;

            //�ִ� ȸ�� �ӵ� ����
            propellerSpeed = Mathf.Clamp(propellerSpeed, 0, 6f);

            //�����緯 ȸ��
            propeller.rotation *= Quaternion.Euler(0, propellerSpeed, 0);
        }

    }

 
    public void TakeOff()
    { 
        if (propellerSpeed >= 1.2f)
        {
            accel += Time.deltaTime * 1.2f; 
            transform.Translate(0, accel* startHeight * Time.deltaTime, 0);
            curHeight = transform.position.y;
        } 
    }

    public void Landing()
    {
        //�ִ� ���� ���� �� �ڷ�ƾ ȣ��
        if(curHeight >= maxHeight)
        {
           fly = StartCoroutine(LandCoroutine()); 
        } 

        //������ ������ �� �ڷ�ƾ ����
        if(fly != null && curHeight == startHeight)
        {
            StopCoroutine(fly);
            fly = null;
        }

    }

    public IEnumerator LandCoroutine()
    {
        isFlying = false;
        propellerSpeed = 0;
        rb.useGravity = true;

        yield return flyWait;

        //���� �ð� ��� �� �ٽ� �̷�?
        propellerSpeed = 0;
        accel = 0;
        curHeight = startHeight;
        isFlying = true;
        rb.useGravity = false;
         
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

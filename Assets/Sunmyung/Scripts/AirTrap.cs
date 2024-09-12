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

        //현재 높이
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
            //프로펠러 점점 빨라지게 회전
            propellerSpeed += rotateSpeed * Time.deltaTime;

            //최대 회전 속도 제한
            propellerSpeed = Mathf.Clamp(propellerSpeed, 0, 6f);

            //프로펠러 회전
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
        //최대 높이 도달 시 코루틴 호출
        if(curHeight >= maxHeight)
        {
           fly = StartCoroutine(LandCoroutine()); 
        } 

        //착륙한 상태일 때 코루틴 중지
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

        //일정 시간 대기 후 다시 이륙?
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
            //게임 종료
            Debug.Log("플레이어 사망");
        }
    }


}

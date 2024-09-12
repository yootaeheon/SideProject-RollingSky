using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- Ŭ���� ���� �ʵ� ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] float SpeedBoost; //�ν�Ʈ �ӵ� ������

    [SerializeField] float SpeedBoostTime; //�ӵ� ���� ���� �ð�

    [SerializeField] Vector3 startPosition;  //�÷��̾��� ó�� ��ġ

    [SerializeField] Transform playerTransform;

    private bool isSpeedBoosted = false; //���� �ν�Ʈ�� ���� ���ΰ�?
    private float originalMoveSpeed; //�ν�Ʈ ���� �� (���� �̵� �ӵ�)�� ����

    //-----------------------------------------------------
    //----------------- ����Ƽ �޽��� �Լ� -----------------
    //----------------------------------------------------

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        originalMoveSpeed = MoveSpeed; //ó���� ���� �̵� �ӵ� �����Ͽ� ���
    }


    void Update()
    {

        //���� ���� y���� ���� -5 �����̸� ��ġ �ʱ�ȭ
        if (playerTransform.position.y <= -5)
        {
            ResetPosition();
        }

        // FŰ�� ������ �ִ� ���ȿ��� �״�� ��������
        if (Input.GetKey(KeyCode.F))
        {
            transform.position += Vector3.zero;
            return;

        }

        //isSpeedBoosted�� true�̸� MoveSpeed�� SpeedBoost ���� �ӵ��� �̵�, false�̸� �⺻ �ӵ��� �̵�
        float currentSpeed = isSpeedBoosted ? MoveSpeed * SpeedBoost : MoveSpeed;
        
        //������ ��� ���� ����
        transform.position += Vector3.forward * currentSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }


    }



    //-----------------------------------------------------
    //------------------ ���� Ŀ���� �Լ� ------------------
    //----------------------------------------------------

    private void ResetPosition()
    {
        transform.position = startPosition;
        playerTransform.position = startPosition;
    }

    public void Die()
    {
        //BSM_TrapCube���� ��ũ��
    }

    //�ӵ� �ν��� �����ϴ� �Լ�
    public void ApplySpeedBoost()
    {
        //�ӵ� �ν�Ʈ�� ����Ǿ� ���� ���� ���¸�
        if (!isSpeedBoosted)
        {
            //�ڷ�ƾ ����
            StartCoroutine(SpeedBoostCoroutine());
        }
    }

    //������ �ð� ���� �ӵ� �ν�Ʈ�� �����ϴ� �ڷ�ƾ
    private IEnumerator SpeedBoostCoroutine()
    {
        //�����ϸ� �ν�Ʈ ���¸� true�� �����ϰ�
        isSpeedBoosted = true;

        //������ SpeedBoostTime��ŭ ����Ǿ��ٰ�
        yield return new WaitForSeconds(SpeedBoostTime);
        
        //�ν�Ʈ ���¸� �ٽ� false�� ����
        isSpeedBoosted = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LYJ_PlayerMove : MonoBehaviour
{
    //----------------- Ŭ���� ���� �ʵ� ------------------

    [SerializeField] float MoveSpeed;

    [SerializeField] Vector3 startPosition;  //�÷��̾��� ó�� ��ġ

    [SerializeField] Transform playerTransform;

    private bool isReversed = false;  //�¿� �̵� ���� ���¸� ����

    //-----------------------------------------------------
    //----------------- ����Ƽ �޽��� �Լ� -----------------
    //----------------------------------------------------

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
        
        //������ ��� ���� ����
        transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (isReversed)
                transform.position += Vector3.right * MoveSpeed * Time.deltaTime; //���� ����
            else
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (isReversed)
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime; //���� ����
            else
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


    //�¿� ������ �����ϴ� �Լ� �߰�
    public void ReverseControls(bool reverse)
    {
        isReversed = reverse;
    }

    //�̵� �ӵ� ���� �Լ�
    public void SetMoveSpeed(float newSpeed)
    {
        MoveSpeed = newSpeed;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }

    //���� ȿ���� �����ϴ� �ڷ�ƾ
    public IEnumerator ActivateShield()
    {
        Renderer playerRenderer = GetComponent<Renderer>();

        if (playerRenderer != null)
        {
            Color originalColor = playerRenderer.material.color;

            //�÷��̾ �������ϰ� ����
            playerRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.4f);
            Debug.Log("���� ȿ�� ����");

            //5�� ���
            yield return new WaitForSeconds(5f);

            //���� �������� ����
            playerRenderer.material.color = originalColor;
            Debug.Log("���� ȿ�� ����");
        }
    }
}

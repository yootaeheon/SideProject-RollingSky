using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���θ޴�1 ���ӿ�����Ʈ�� ������Ʈ�� �־��ֱ�!
public class LSH_SceneChanger1 : MonoBehaviour
{

    private GameObject Scene1_EventBtn;             //�������� �������� ��ư
    [SerializeField] GameObject Scene1_EventCanvas; //���� ��ư ������ Ƣ��� ������
    //private GameObject Scene1_Btn1;           //���η� ���� 1��¥�� ��ư
    //private GameObject Scene1_Btn2;           //������ 3��¥�� ��ư �� ����
    //private GameObject Scene1_Btn3;           //������ 3��¥�� ��ư �� �߰�
    //private GameObject Scene1_Btn4;           //������ 3��¥�� ��ư �� ������


    public void ViewEventUI()
    {
        //�������� ��ư ������ UI�� ����
        Scene1_EventCanvas.SetActive(true);
    }

    public void ignoranceEventUI()
    {
        //UI ������ X��ư ������ UI ����
        Scene1_EventCanvas.SetActive(false);
    }



    public void Scene1_Btn1()
    {
        // ĵ������ LSH_ButtonEvent���� .ClickBtn3()�� ���� ������ ��,
        // �ش� ��ũ��Ʈ���� ���� �������� �̺�Ʈ ���� ���� ���� �����ִ� �ڵ� �ۼ��ϱ�
        //btnEvent.ClickBtn3();
        Debug.LogWarning("Code 11: ���� �������� �̺�Ʈ ���� ���� ���� �����ؾ� �մϴ�.");

    }

    public void Scene1_Btn2()
    {
        // ĵ������ LSH_ButtonEvent���� .ClickBtn2()�� �����ϰ�, ������ ���������� ���Կ��� UI�� �����,
        // ������� �������� �ʾ�����, ������ ������ ���������� �������� �����ִ� ��� �����ϱ�
        //btnEvent.ClickBtn2();
        Debug.LogWarning("Code 12: ������ �ش� ���������� ���Կ��� UI�� ǥ���ؾ� �մϴ�.");

    }

    public void Scene1_Btn3()
    {
        // ĵ������ LSH_ButtonEvent���� .ClickBtn2()�� �����ϰ�, ������ ���������� ���Կ��� UI�� �����,
        // ������� �������� �ʾ�����, ������ ������ ���������� �������� �����ִ� ��� �����ϱ�
        //btnEvent.ClickBtn2();
        Debug.LogWarning("Code 13: ������ �ش� ���������� ���Կ��� UI�� ǥ���ؾ� �մϴ�.");

    }

    public void Scene1_Btn4()
    {
        // ĵ������ LSH_ButtonEvent���� .ClickBtn3()�� ���� ������ ��, "���� ����" ���Կ��� UI�� �����,
        // ���� �������� �̺�Ʈ ���� �� �߿��� ���� ����������(���� �ֱٿ�) �÷����� ���� ������
        //btnEvent.ClickBtn3();
        Debug.LogWarning("Code 14: ����ʿ��� ���� �������� ����ߴٰ� �̰��� �����ؾ� �մϴ�.");

    }

}

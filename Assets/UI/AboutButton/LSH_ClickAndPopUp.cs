using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LSH_ClickAndPopUp : MonoBehaviour
{
    [SerializeField] GameObject canvas;      //�ֻ��� ĵ������ ������
    [SerializeField] GameObject menu_Event;  //1��° �޴��� �̺�Ʈ ��ư �˾�
    [SerializeField] GameObject menu_Season; //3��° �޴����� ������ �������� ����� �˾�


    private void Start()
    {
        canvas.SetActive(true);
        menu_Event.SetActive(false);
        menu_Season.SetActive(false);

    }



    // �޴� ���� (����ȯ ���� ����� �̹��� �˾�)
    public void Change_Stage_PopUp()
    {
        Debug.Log("������ stage ��������?");

    }

    public void Change_Season_PopUp()
    {
        Debug.Log("����� season ��������?");

    }

    public void Change_Random_PopUp()
    {
        Debug.Log("�������� ������ �� ���� ��������?");

        LSH_TapButtonClick btn = canvas.GetComponent<LSH_TapButtonClick>();

        //if (�������� ������ ���� �Ϲ� �����������)
        //    btn.OnClickTapBtn2();
        //else if (���� ���� ������� �����������)
        //    btn.OnClickTapBtn3();


    }

    public void Change_Last_PopUp()
    {
        Debug.Log("���������� �ߴ� �� ��������?");

        LSH_TapButtonClick btn = canvas.GetComponent<LSH_TapButtonClick>();

        //if (���������� �ߴ� ���� �Ϲ� �����������)
        //    btn.OnClickTapBtn2();
        //else if (������ ���� ������� �����������)
        //    btn.OnClickTapBtn3();
            

    }





    // 1��° �޴��� �̺�Ʈ ��ư �˾�
    public void Menu1_Event_Open()
    {
        menu_Event.SetActive(true);

    }
    public void Menu1_Event_Close()
    {
        menu_Event.SetActive(false);

    }



    // 3��° �޴��� �̺�Ʈ ��ư �˾�
    //(������ 1���� ������, ���߿� �迭�̳� ��ųʸ� ������ �ٲ㺸��)
    public void Menu3_Season_Open()
    {
        menu_Season.SetActive(true);

    }

    public void Menu3_Season_Close()
    {
        menu_Season.SetActive(false);

    }






}

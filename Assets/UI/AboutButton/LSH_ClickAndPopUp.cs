using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class LSH_ClickAndPopUp : MonoBehaviour
{

    [SerializeField] GameObject canvas;         // �ֻ��� ĵ������ ������

    [SerializeField] GameObject menu_Event;     //1��° �޴��� �̺�Ʈ ��ư �˾�
    [SerializeField] GameObject menu_Season;    //3��° �޴����� ������ �������� ����� �˾�

    [SerializeField] GameObject menu_language;  //5��° �޴�, ��� ���� �˾�â 

                     bool isBgmOn;              //������� ��ư �����ִ���
    [SerializeField] Button menu_BGM;           //5��° �޴�, ������� ��ư
    [SerializeField] Sprite menu_BGM_On;        //5��° �޴�, ������� �ѱ�
    [SerializeField] Sprite menu_BGM_Off;       //5��° �޴�, ������� ����

                     bool isSfxOn;              //���� ��ư �����ִ���
    [SerializeField] Button menu_SFX;           //5��° �޴�, ���� ��ư
    [SerializeField] Sprite menu_SFX_On;        //5��° �޴�, ���� �ѱ�
    [SerializeField] Sprite menu_SFX_Off;       //5��° �޴�, ���� ����


    private void Start()
    {
        canvas.SetActive(true);
        menu_Event.SetActive(false);
        menu_Season.SetActive(false);
        isBgmOn = true;
        isSfxOn = true;

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

        LSH_TapMenuClick menu = canvas.GetComponent<LSH_TapMenuClick>();

        //if (�������� ������ ���� �Ϲ� �����������)
        //    menu.OnClickTapBtn2();
        //else if (���� ���� ������� �����������)
        //    menu.OnClickTapBtn3();


    }

    public void Change_Last_PopUp()
    {
        Debug.Log("���������� �ߴ� �� ��������?");

        LSH_TapMenuClick menu = canvas.GetComponent<LSH_TapMenuClick>();

        //if (���������� �ߴ� ���� �Ϲ� �����������)
        //    menu.OnClickTapBtn2();
        //else if (������ ���� ������� �����������)
        //    menu.OnClickTapBtn3();


    }

    public void PopUpInternet()
    {
        Debug.Log("�������� ��ȣ��å�� ������Ű�� ���� ������ ���ͳ� â�� ���ϴ�.");
    }

    public void AdjustQuality()
    {
        Debug.Log("��ư�� ���������� �ػ� ����Ƽ�� ��-��-���� ������� �ٲ�ϴ�.");
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



    // 5��° �޴��� ��� ������ư �˾�â
    public void Menu5_Language_Open()
    {
        menu_language.SetActive(true);

    }

    public void Menu5_Language_Close()
    {
        menu_language.SetActive(false);

    }


    // 5��° �޴��� ������� �Ѱ� ���� + ��������Ʈ ��ü�ϱ�
    public void Menu5_OnOff_BGM() 
    {
        if (isBgmOn == true)
        {
            isBgmOn = false;
            menu_BGM.GetComponent<Image>().sprite = menu_BGM_Off;
            Debug.LogWarning("[LSH] ���� �Ŵ����� BGM�� ������ �ʿ��մϴ�.");
        }
        else
        {
            isBgmOn = true;
            menu_BGM.GetComponent<Image>().sprite = menu_BGM_On;
            Debug.LogWarning("[LSH] ���� �Ŵ����� BGM�� ������ �ʿ��մϴ�.");

        }

        
    }


    // 5��° �޴��� ����(ȿ����) �Ѱ� ���� + ��������Ʈ ��ü�ϱ�
    public void Menu5_OnOff_SFX()
    {
        if (isSfxOn == true)
        {
            isSfxOn = false;
            menu_SFX.GetComponent<Image>().sprite = menu_SFX_Off;
            Debug.LogWarning("[LSH] ���� �Ŵ����� SFX�� ������ �ʿ��մϴ�.");
        }
        else
        {
            isSfxOn = true;
            menu_SFX.GetComponent<Image>().sprite = menu_SFX_On;
            Debug.LogWarning("[LSH] ���� �Ŵ����� SFX�� ������ �ʿ��մϴ�.");

        }


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�̰� �����ϰ� Ŀ�� ��

public class LSH_TapButtonClick : MonoBehaviour
{
    //�ֻ��� ĵ������ ������Ʈ�� �־��� ��ũ��Ʈ

    [SerializeField] GameObject menu1_Img;  //�޴�1: Ȩ ��
    [SerializeField] GameObject menu2_Img;  //�޴�2: �ܰ� ��
    [SerializeField] GameObject menu3_Img;  //�޴�3: �����̺�Ʈ �� (���� �ҷ��� �޴�)
    [SerializeField] GameObject menu4_Img;  //�޴�4: ���� ��
    [SerializeField] GameObject menu5_Img;  //�޴�5: ���� ��


    // �޴����� �����ϸ� Ȩ ���� �̹����� ��������
    void Start()
    {
        menu1_Img.SetActive(true);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // �ϴ� �ǿ��� 1��° ��ư�� ������ �޴�1�� �̹����� ��ȯ��
    public void OnClickBtn1()
    {
        menu1_Img.SetActive(true);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // �ϴ� �ǿ��� 2��° ��ư�� ������ �޴�2�� �̹����� ��ȯ��
    public void OnClickBtn2()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(true);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // �ϴ� �ǿ��� 3��° ��ư�� ������ �޴�3�� �̹����� ��ȯ��
    public void OnClickBtn3()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(true);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // �ϴ� �ǿ��� 4��° ��ư�� ������ �޴�4�� �̹����� ��ȯ��
    public void OnClickBtn4()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(true);
        menu5_Img.SetActive(false);
    }

    // �ϴ� �ǿ��� 5��° ��ư�� ������ �޴�5�� �̹����� ��ȯ��
    public void OnClickBtn5()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(true);
    }


}

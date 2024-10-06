using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//이거 연결하고 커밋 ㄱ

public class LSH_TapButtonClick : MonoBehaviour
{
    //최상위 캔버스에 컴포넌트로 넣어줄 스크립트

    [SerializeField] GameObject menu1_Img;  //메뉴1: 홈 탭
    [SerializeField] GameObject menu2_Img;  //메뉴2: 단계 탭
    [SerializeField] GameObject menu3_Img;  //메뉴3: 시즌이벤트 탭 (현재 할로윈 메뉴)
    [SerializeField] GameObject menu4_Img;  //메뉴4: 상점 탭
    [SerializeField] GameObject menu5_Img;  //메뉴5: 설정 탭


    // 메뉴씬에 진입하면 홈 탭의 이미지만 켜져있음
    void Start()
    {
        menu1_Img.SetActive(true);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // 하단 탭에서 1번째 버튼을 누르면 메뉴1의 이미지로 전환됨
    public void OnClickBtn1()
    {
        menu1_Img.SetActive(true);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // 하단 탭에서 2번째 버튼을 누르면 메뉴2의 이미지로 전환됨
    public void OnClickBtn2()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(true);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // 하단 탭에서 3번째 버튼을 누르면 메뉴3의 이미지로 전환됨
    public void OnClickBtn3()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(true);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(false);
    }

    // 하단 탭에서 4번째 버튼을 누르면 메뉴4의 이미지로 전환됨
    public void OnClickBtn4()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(true);
        menu5_Img.SetActive(false);
    }

    // 하단 탭에서 5번째 버튼을 누르면 메뉴5의 이미지로 전환됨
    public void OnClickBtn5()
    {
        menu1_Img.SetActive(false);
        menu2_Img.SetActive(false);
        menu3_Img.SetActive(false);
        menu4_Img.SetActive(false);
        menu5_Img.SetActive(true);
    }


}

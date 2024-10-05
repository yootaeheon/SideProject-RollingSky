using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 메인메뉴1 게임오브젝트에 컴포넌트로 넣어주기!
public class LSH_SceneChanger1 : MonoBehaviour
{

    private GameObject Scene1_EventBtn;             //왼쪽위의 선물상자 버튼
    [SerializeField] GameObject Scene1_EventCanvas; //위의 버튼 누르면 튀어나올 유아이
    //private GameObject Scene1_Btn1;           //가로로 넓은 1개짜리 버튼
    //private GameObject Scene1_Btn2;           //나열된 3개짜리 버튼 중 왼쪽
    //private GameObject Scene1_Btn3;           //나열된 3개짜리 버튼 중 중간
    //private GameObject Scene1_Btn4;           //나열된 3개짜리 버튼 중 오른쪽


    public void ViewEventUI()
    {
        //선물상자 버튼 누르면 UI가 열림
        Scene1_EventCanvas.SetActive(true);
    }

    public void ignoranceEventUI()
    {
        //UI 내부의 X버튼 누르면 UI 닫힘
        Scene1_EventCanvas.SetActive(false);
    }



    public void Scene1_Btn1()
    {
        // 캔버스의 LSH_ButtonEvent에서 .ClickBtn3()을 직접 연결한 뒤,
        // 해당 스크립트에서 현재 진행중인 이벤트 시즌 맵의 탭을 보여주는 코드 작성하기
        //btnEvent.ClickBtn3();
        Debug.LogWarning("Code 11: 현재 진행중인 이벤트 시즌 맵의 탭을 연결해야 합니다.");

    }

    public void Scene1_Btn2()
    {
        // 캔버스의 LSH_ButtonEvent에서 .ClickBtn2()을 연결하고, 랜덤한 스테이지의 진입여부 UI를 띄워서,
        // 현재까지 도달하지 않았지만, 진입이 가능한 스테이지를 랜덤으로 보여주는 기능 구현하기
        //btnEvent.ClickBtn2();
        Debug.LogWarning("Code 12: 랜덤한 해당 스테이지의 진입여부 UI를 표시해야 합니다.");

    }

    public void Scene1_Btn3()
    {
        // 캔버스의 LSH_ButtonEvent에서 .ClickBtn2()을 연결하고, 랜덤한 스테이지의 진입여부 UI를 띄워서,
        // 현재까지 도달하지 않았지만, 진입이 가능한 스테이지를 랜덤으로 보여주는 기능 구현하기
        //btnEvent.ClickBtn2();
        Debug.LogWarning("Code 13: 랜덤한 해당 스테이지의 진입여부 UI를 표시해야 합니다.");

    }

    public void Scene1_Btn4()
    {
        // 캔버스의 LSH_ButtonEvent에서 .ClickBtn3()을 직접 연결한 뒤, "지난 레벨" 진입여부 UI를 띄워서,
        // 현재 진행중인 이벤트 시즌 맵 중에서 가장 마지막으로(가장 최근에) 플레이한 맵을 보여줌
        //btnEvent.ClickBtn3();
        Debug.LogWarning("Code 14: 시즌맵에서 지난 레벨씬을 기억했다가 이곳에 연결해야 합니다.");

    }

}

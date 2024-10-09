using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class LSH_ClickAndPopUp : MonoBehaviour
{

    [SerializeField] GameObject canvas;         // 최상위 캔버스를 역참조

    [SerializeField] GameObject menu_Event;     //1번째 메뉴의 이벤트 버튼 팝업
    [SerializeField] GameObject menu_Season;    //3번째 메뉴에서 각각의 씬에대한 썸네일 팝업

    [SerializeField] GameObject menu_language;  //5번째 메뉴, 언어 선택 팝업창 

                     bool isBgmOn;              //배경음악 버튼 켜져있는지
    [SerializeField] Button menu_BGM;           //5번째 메뉴, 배경음악 버튼
    [SerializeField] Sprite menu_BGM_On;        //5번째 메뉴, 배경음악 켜기
    [SerializeField] Sprite menu_BGM_Off;       //5번째 메뉴, 배경음악 끄기

                     bool isSfxOn;              //사운드 버튼 켜져있는지
    [SerializeField] Button menu_SFX;           //5번째 메뉴, 사운드 버튼
    [SerializeField] Sprite menu_SFX_On;        //5번째 메뉴, 사운드 켜기
    [SerializeField] Sprite menu_SFX_Off;       //5번째 메뉴, 사운드 끄기


    private void Start()
    {
        canvas.SetActive(true);
        menu_Event.SetActive(false);
        menu_Season.SetActive(false);
        isBgmOn = true;
        isSfxOn = true;

    }



    // 메뉴 공통 (씬전환 여부 물어보는 이미지 팝업)
    public void Change_Stage_PopUp()
    {
        Debug.Log("기존맵 stage 깨러갈래?");

    }

    public void Change_Season_PopUp()
    {
        Debug.Log("시즌맵 season 깨러갈래?");

    }

    public void Change_Random_PopUp()
    {
        Debug.Log("랜덤으로 보여준 이 맵을 깨러갈래?");

        LSH_TapMenuClick menu = canvas.GetComponent<LSH_TapMenuClick>();

        //if (랜덤으로 보여준 맵이 일반 스테이지라면)
        //    menu.OnClickTapBtn2();
        //else if (랜덤 맵이 시즌맵의 스테이지라면)
        //    menu.OnClickTapBtn3();


    }

    public void Change_Last_PopUp()
    {
        Debug.Log("마지막으로 했던 맵 깨러갈래?");

        LSH_TapMenuClick menu = canvas.GetComponent<LSH_TapMenuClick>();

        //if (마지막으로 했던 맵이 일반 스테이지라면)
        //    menu.OnClickTapBtn2();
        //else if (마지막 맵이 시즌맵의 스테이지라면)
        //    menu.OnClickTapBtn3();


    }

    public void PopUpInternet()
    {
        Debug.Log("개인정보 보호정책을 열람시키기 위해 강제로 인터넷 창을 띄웁니다.");
    }

    public void AdjustQuality()
    {
        Debug.Log("버튼을 누를때마다 해상도 퀄리티가 상-중-하의 순서대로 바뀝니다.");
    }







    // 1번째 메뉴의 이벤트 버튼 팝업
    public void Menu1_Event_Open()
    {
        menu_Event.SetActive(true);

    }
    public void Menu1_Event_Close()
    {
        menu_Event.SetActive(false);

    }



    // 3번째 메뉴의 이벤트 버튼 팝업
    //(지금은 1개만 만들어둠, 나중에 배열이나 딕셔너리 등으로 바꿔보기)
    public void Menu3_Season_Open()
    {
        menu_Season.SetActive(true);

    }

    public void Menu3_Season_Close()
    {
        menu_Season.SetActive(false);

    }



    // 5번째 메뉴의 언어 설정버튼 팝업창
    public void Menu5_Language_Open()
    {
        menu_language.SetActive(true);

    }

    public void Menu5_Language_Close()
    {
        menu_language.SetActive(false);

    }


    // 5번째 메뉴의 배경음악 켜고 끄기 + 스프라이트 교체하기
    public void Menu5_OnOff_BGM() 
    {
        if (isBgmOn == true)
        {
            isBgmOn = false;
            menu_BGM.GetComponent<Image>().sprite = menu_BGM_Off;
            Debug.LogWarning("[LSH] 사운드 매니저의 BGM과 연결이 필요합니다.");
        }
        else
        {
            isBgmOn = true;
            menu_BGM.GetComponent<Image>().sprite = menu_BGM_On;
            Debug.LogWarning("[LSH] 사운드 매니저의 BGM과 연결이 필요합니다.");

        }

        
    }


    // 5번째 메뉴의 사운드(효과음) 켜고 끄기 + 스프라이트 교체하기
    public void Menu5_OnOff_SFX()
    {
        if (isSfxOn == true)
        {
            isSfxOn = false;
            menu_SFX.GetComponent<Image>().sprite = menu_SFX_Off;
            Debug.LogWarning("[LSH] 사운드 매니저의 SFX와 연결이 필요합니다.");
        }
        else
        {
            isSfxOn = true;
            menu_SFX.GetComponent<Image>().sprite = menu_SFX_On;
            Debug.LogWarning("[LSH] 사운드 매니저의 SFX와 연결이 필요합니다.");

        }


    }


}

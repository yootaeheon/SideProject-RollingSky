using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LSH_ClickAndPopUp : MonoBehaviour
{
    [SerializeField] GameObject canvas;      //최상위 캔버스를 역참조
    [SerializeField] GameObject menu_Event;  //1번째 메뉴의 이벤트 버튼 팝업
    [SerializeField] GameObject menu_Season; //3번째 메뉴에서 각각의 씬에대한 썸네일 팝업


    private void Start()
    {
        canvas.SetActive(true);
        menu_Event.SetActive(false);
        menu_Season.SetActive(false);

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

        LSH_TapButtonClick btn = canvas.GetComponent<LSH_TapButtonClick>();

        //if (랜덤으로 보여준 맵이 일반 스테이지라면)
        //    btn.OnClickTapBtn2();
        //else if (랜덤 맵이 시즌맵의 스테이지라면)
        //    btn.OnClickTapBtn3();


    }

    public void Change_Last_PopUp()
    {
        Debug.Log("마지막으로 했던 맵 깨러갈래?");

        LSH_TapButtonClick btn = canvas.GetComponent<LSH_TapButtonClick>();

        //if (마지막으로 했던 맵이 일반 스테이지라면)
        //    btn.OnClickTapBtn2();
        //else if (마지막 맵이 시즌맵의 스테이지라면)
        //    btn.OnClickTapBtn3();
            

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






}

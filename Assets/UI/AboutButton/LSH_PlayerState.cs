using System.Collections;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LSH_PlayerState : MonoBehaviour
{
    /* 
     * If you need, You can change this code to Singleton. 필요하시면 싱글톤으로 수정하셔도 됩니다!! 
     * It's not UI binding yet. 아직 유아이 바인딩이 되지 않아서 에디터에서 일일이 수정해야 합니다 ㅠㅠ 죄송합니다!
     */

    [SerializeField] LSH_LoadingGame Canvas;

    enum PlayerState { Ready, Running, Pause, UnPause, Clear, Gameover, ReStart, Quit };
    [SerializeField] PlayerState playerState;

    [SerializeField] bool isDead;    // 플레이어가 피격을 입었을 경우입니다만, 아직 연결되지 않았습니다.
    [SerializeField] bool isUnPause; //일시정지를 풀었을때 3초 카운팅을 위해 만들었습니다. 얘가 T면 
    [SerializeField] bool isMooJeok; //플레이어가 죽었다가 이어하기 눌렀을때 입니다. 3초동안 아묻따 무적이 되고 또 냅다 풀립니다.
    Coroutine unPauseRoutine;  // 일시정지 해제용 3초짜리 코루틴.
    Coroutine BuHwalRoutine;  // 게임 이어하기용도 3초짜리 코루틴.

    [SerializeField] GameObject GameReadyUI;     //게임 시작전인 대기중에 계속 떠있는 UI
    [SerializeField] GameObject GameRunningUI;   //게임 시작부터 진행중에 계속 떠있는 UI
    [SerializeField] TMP_Text GameprogressTMP;   //게임 러닝중에 계속 떠있는 진행률 퍼센트 TMP
    [SerializeField] GameObject GamePauseUI;     //게임 중간에 띄울 퍼즈UI (온오프)
    [SerializeField] TMP_Text GameUnPauseTMP;    //퍼즈UI를 껐을때 나올 3초짜리 카운트다운 TMP
    [SerializeField] GameObject GameClearUI;     //게임 클리어시 띄울 UI (터치 전까지 계속 떠있음)
    [SerializeField] GameObject GameoverUI;      //게임 오버시에 띄울 UI (터치 전까지 계속 떠있음, 재도전 가능)
                                                 //재도전은 UI가 없습니다. 그냥 잠깐 리스타트 상태였다가 다시 러닝상태로 바뀔거라서요.. 

    /*
     * <각 상태 설명>
     * 
     * isDead:    플레이어 사망한 상황. (얘가 T라면 플레이어 상태를 게임오버로 교체함)
     * isUnPause: 일시정지를 누른 상황. (얘가 T라면 3초 카운트가 시작됨, 코루틴 씀)
     * isMooJeok: 플레이어 무적인 상황. (얘가 T라면 3초동안 무적, 코루틴 씀)
     * 
     * 
     * Ready:   게임 시작전, 대기중. 게임시간 멈춤. (터치 한번 하면 게임시작 UI로 교체)
     * 
     * Running:  게임시작 ~ 진행중,    시간 흐름.  (게임시작 후 시간이 흐름에 따라 맵의 진척도를 오른쪽 위에 %로 표시.)
     * Pause:    퍼즈 버튼 눌렀을때,   시간 멈춤.  (일시정지 팝업 UI 실행, 게임 멈춰있음)
     * UnPause:   일시정지에서 탈출시, 시간 흐름.  (일시정지 팝업 UI 해제, 3초동안 게임은 멈춰있고 타이머만 움직임, 3초뒤 게임 재개)
     * 
     * Clear:    게임 클리어,         시간 멈춤.   (게임클리어 UI로 교체, 게임 멈춤, 진척도 100% 달성으로 표기)      * 
     * Gameover: 게임오버,            시간 멈춤.   (재도전 선택가능, 재도전 미선택시 게임오버 UI 띄움)
     * ReStart:  게임 이어하기,       시간 흐름.   (재도선 선택시. 하트 1개 소모 UI 띄운 뒤 다짜고짜 3초간 무적으로 게임 재개)
     *
     * Quit:     게임씬 이탈,         시간 멈춤.   (일시정지 or 게임클리어 or 게임오버시 왼쪽 위 버튼을 선택해 로비씬으로 나가는 중일때)
     *
     */




    private void Awake()
    {
        Debug.LogError("코루틴 작성했으나 테스트 안해봤어요. 컴퓨터 터짐 주의!"); // 181번째 줄에서 이어집니다.
        Debug.LogWarning("여유 되시는분들 계신다면 \n 10, 81-82, 192번째줄 수정해주셔도 됩니다");
        // 95번째 줄은 싱글톤 데이터와 연결 요청,
        // 145번째, 230째 줄은 기능구현 요청이고,
        // 나머지는 전부 코드 설명이에요!!

    }

    private void Start()
    {
        //게임 시작시 Ready상태로 고정
        playerState = PlayerState.Ready;
    }

    private void Update()
    {
        //상태를 계속 추적해야해서 Update로 놓긴 했지만,
        //이벤트-콜백 등 형태로 바꿀 필요가 있다면 의견 주시거나, 직접 바꾸셔도 됩니다!

        switch (playerState)
        {
            case PlayerState.Ready:
                //"좌우로 스크롤하세요" <-이게 버튼역할, 버튼 누르면 playerState가 Running으로 넘어감                
                isDead = false;
                isUnPause = false;
                isMooJeok = false;
                GameReadyUI.SetActive(true);
                GameRunningUI.SetActive(false);
                GamePauseUI.SetActive(false);
                GameUnPauseTMP.text = "";
                GameClearUI.SetActive(false);
                GameoverUI.SetActive(false);
                Time.timeScale = 0f;
                break;

            case PlayerState.Running:
                //게임 시작 시간에 따른 퍼센트 정보가 뜸 (0 ~ 100 정수 단위로 오른쪽 위에 표시됨)
                GameReadyUI.SetActive(false);
                GameRunningUI.SetActive(true);                
                //GameprogressTMP.text = ""; 
                //Debug.LogWarning("싱글톤에서 게임 퍼센테이지 연동 부탁드립니다!");
                Time.timeScale = 1f;
                break;

            case PlayerState.Pause:
                //퍼즈 버튼을 눌렀을때 뜨는 UI입니다. 로비로 나가거나, 게임을 재개할 수 있습니다.
                GamePauseUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case PlayerState.UnPause:
                //퍼즈 버튼을 눌렀다가 게임을 재개한 경우입니다. 3초짜리 카운트다운이 표시됩니다. (소수점 첫째자리까지)
                GamePauseUI.SetActive(false);                
                isUnPause = true; //112번째줄로 이어집니다
                break;

            case PlayerState.Clear:
                //게임 클리어시 해당 유아이가 나옵니다만 아직 깨본적이 없습니다.. 그래서 미구현 이미지로 표현했어요..
                GameClearUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case PlayerState.Gameover:
                //게임오버시 유아이, 게임 포기 or 게임 이어하기를 선택할수 있어요.
                GameoverUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case PlayerState.ReStart:
                //죽었다가 부활기회를 얻고 세이브 포인트에서 부터 이어서 진행하는 경우입니다. (이어하기)
                GameoverUI.SetActive(false);
                isDead = false;
                isMooJeok = true;
                break;

            case PlayerState.Quit:
                //여러 상황에서 게임을 포기하고 로비로 나가는 경우입니다. 로비씬을 불러옵니다.
                Canvas.GotoGame("LSH_Scene_Menu");
                break;


        }


        //플레이어 죽으면
        if (playerState == PlayerState.Running && isDead == true)
        {
            //플레이어 터지는 모션 함수
            PlayerDead();

        }



        //일시정지 해제시 코루틴
        if (isUnPause == true)
        {
            unPauseRoutine = StartCoroutine(CountDown(3.0f));
        }
        else if (unPauseRoutine != null && isUnPause == false)
        {

            //카운트다운 종료 후 게임 재개
            StopCoroutine(unPauseRoutine);

        }



        //이어하기 선택시 코루틴
        if (isMooJeok == true)
        {
            Time.timeScale = 1f;
            BuHwalRoutine = StartCoroutine(ReStartRoutine(3.0f));

        }
        else if (BuHwalRoutine != null && isMooJeok == false)
        {

            //게임 이어하기 선택시 부여받은 무적시간 종료 후 일반적인 게임 진행
            StopCoroutine(BuHwalRoutine);
            
        }


    }




    public void PlayerDead()
    {
        if (isDead == false) return;

        playerState = PlayerState.Gameover;

    }

    public void ReadyStart()
    {
        playerState = PlayerState.Running;
    }

    public void ClickPause()
    {
        playerState = PlayerState.Pause;
    }

    public void ClickUnPause()
    {
        playerState = PlayerState.UnPause;
    }

    public void Resurrection()
    {
        playerState = PlayerState.ReStart;

    }





    public IEnumerator CountDown(float countDownNum)
    {

        while (true)
        {            

            if (countDownNum <= 0f)
            {
                //카운트다운 종료 후 게임 재개                
                isUnPause = false;
                GameUnPauseTMP.text = "";
                playerState = PlayerState.Running;
                break;
            }

            //숫자가 줄어듦, 그걸 표시해줌 -----> 근데 이상하게 줄어요......
            countDownNum -= 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            GameUnPauseTMP.text = (countDownNum).ToString("F1");

        }


    }



    public IEnumerator ReStartRoutine(float muJeckSiGan)
    {
        
        while (true)
        {
            Debug.Log("플레이어가 번쩍거리고 낙사제외 무적판정이에요.");
            //Debug.LogWarning("기능 구현 부탁드립니다!");

            if (muJeckSiGan <= 0f)
            {
                //플레이어 무적상태를 해제해요
                isMooJeok = false;
                playerState = PlayerState.Running;
                break;
            }

            //3초동안 플레이어 무적 숫자가 줄어듦, 표시할필요X
            muJeckSiGan -= 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);

        }


    }



}

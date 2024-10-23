using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_PlayerState : MonoBehaviour
{
    enum PlayerState { Ready, Running, Pause, UnPause, Clear, Gameover, ReStart };
    [SerializeField] PlayerState playerState;
    [SerializeField] bool isDead;
    [SerializeField] bool isMooJeok;

    [SerializeField] GameObject GameReadyUI;     //게임 시작전인 대기중에 계속 떠있는 UI
    [SerializeField] GameObject GameRunningUI;   //게임 시작부터 진행중에 계속 떠있는 UI
    [SerializeField] GameObject GameClearUI;     //게임 클리어시 띄울 UI (터치 전까지 계속 떠있음)
    [SerializeField] GameObject GameGameoverUI;  //게임 오버시에 띄울 UI (터치 전까지 계속 떠있음, 재도전 가능)
    [SerializeField] GameObject GamePauseUI;     //게임 중간에 띄울 퍼즈UI (온오프)
    [SerializeField] GameObject GameUnPauseUI;   //퍼즈UI를 껐을때 나올 3초짜리 카운트다운
                                                 //재도전은 UI가 없습니다. 그냥 잠깐 리스타트 상태였다가 다시 러닝상태로 바뀔거라서요.. 

    /*
     * <각 상태 설명>
     * Ready:   게임 시작전, 대기중. 게임시간 멈춤. (터치 한번 하면 게임시작 UI로 교체)
     * 
     * Running:  게임시작 ~ 진행중,    시간 흐름.  (게임시작 후 시간이 흐름에 따라 맵의 진척도를 오른쪽 위에 %로 표시.)
     * Pause:    퍼즈 버튼 눌렀을때,   시간 멈춤.  (일시정지 팝업 UI 실행, 게임 멈춰있음)
     * UnPause:   일시정지에서 탈출시, 시간 흐름.  (일시정지 팝업 UI 해제, 3초동안 게임은 멈춰있고 타이머만 움직임, 3초뒤 게임 재개)
     * 
     * Clear:    게임 클리어,         시간 멈춤.   (게임클리어 UI로 교체, 게임 멈춤, 진척도 100% 달성으로 표기)      * 
     * Gameover: 게임오버,            시간 멈춤.   (재도전 선택가능, 재도전 미선택시 게임오버 UI 띄움)
     * ReStart:  게임 재시작,         시간 흐름.   (재도선 선택시. 하트 1개 소모 UI 띄운 뒤 다짜고짜 3초간 무적으로 게임 재개)
     *
     *
     * 필요없을수도 있는 bool 변수, 일단 놔두자
     * isPause:   일시정지를 누른 상황. (얘가 T라면 플레이어 상태를 퍼즈로 교체함)
     * isDead:    플레이어 사망한 상황. (얘가 T라면 플레이어 상태를 게임오버로 교체함)
     * isMooJeok: 플레이어 무적인 상황. (얘가 T라면 3초뒤에 게임시작, 3초동안 무적)
     */




    private void Awake()
    {
        Debug.LogError("스크립트 손보는중!!");
        Debug.LogError("퍼즈 bool로 바꿀게요!!");
    }

    private void Start()
    {
        playerState = PlayerState.Ready;
    }

    private void Update()
    {

        PlayerDead();

    }


    public void PlayerDead()
    {
        if (isDead == false) return;

        Time.timeScale = 0f;

    }

}

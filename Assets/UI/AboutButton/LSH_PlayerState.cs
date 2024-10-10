using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_PlayerState : MonoBehaviour
{
    enum PlayerState { Ready, Start, Pause, UnPause, Clear, Gameover };
    [SerializeField] bool isDead;
    [SerializeField] bool isMooJeok;

    /*
     * 각 상태 설명
     * Ready:   게임 시작전, 게임 멈춤. 시간 멈춤. (터치 한번 하면 게임시작 UI로 교체)
     * 
     * Start:    게임 시작 ~ 진행중,  시간 흐름.  (게임시작 후 시간이 흐름에 따라 맵의 진척도를 오른쪽 위에 %로 표시.)
     * Pause:    퍼즈 버튼 눌렀을때,  시간 멈춤.  (일시정지 팝업 UI 실행)
     * UnPause:   일시정지에서 탈출시, 시간 흐름.  (일시정지 팝업 UI 중지, 잠깐 멈췄다가 게임 코루틴으로 3초뒤 게임 재개)
     * Clear:    게임 클리어,        겜멈춤.     (게임클리어 UI로 교체, 게임 멈춤, 진척도 100% 달성으로 표기) 
     * Gameover: 게임오버,           게임 멈춤.  (재도전 선택가능, 재도전시 하트 1개 소모하고 무적으로 게임 재개)
     * 
     *
     * isDead:    플레이어 사망한 상황. (얘가 T라면 플레이어 상태를 게임오버로 교체함)
     * isMooJeok: 플레이어 무적인 상황. (얘가 T라면 3초뒤에 게임)
     */




    private void Awake()
    {
        Debug.LogError("스크립트 손보는중!!");
        Debug.LogError("퍼즈 bool로 바꿀게요!!");
        Debug.LogError("무적으로 게임 재개하는걸 Resume State로 바꿀게요!!");
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

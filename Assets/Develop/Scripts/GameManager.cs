using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int stageGem; //한 스테이지 내에서 획득한 보석 갯수
    public int totalGem; //총 보석 갯수

    public bool isGameOver = false;

    private float startTime;
    private float elapsedTime;

   
    public float bestTime = float.MaxValue;   // 최단 시간 기록 
                                              // 첫 플레이어 기록 = 최단 시간

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void StartGame() // 게임 시작 로직
    {
        isGameOver = false;

        // 게임 시작 시간 기록
        startTime = Time.time;
    }

    public void GameOver()   // 게임 종료 로직
    {
        isGameOver = true;

        // 게임 종료 시 시간 계산
        elapsedTime = Time.time - startTime;

        // 최단 시간 갱신
        if (elapsedTime < bestTime)
        {
            bestTime = elapsedTime;
            Debug.Log("최단 기록! 새로운 기록: " + bestTime + "초");
        }
        else
        {
            Debug.Log("게임 종료. 소요 시간: " + elapsedTime + "초");
        }
    }

    // 플레이어가 점수를 얻었을 때 호출하는 함수
    public void AddGem(int GemCount)
    {
        if (!isGameOver)
        {
            stageGem += GemCount;
            totalGem += GemCount;
        }
    }
}
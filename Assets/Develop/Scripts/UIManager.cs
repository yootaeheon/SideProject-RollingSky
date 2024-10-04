using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

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

   
  //  public void UpdateScoreUI()  //보석 갯수 업데이트
  //  {
  //     
  //      Debug.Log("UI 업데이트: Gem : " + );
  //  }

   
    public void ShowGameOverScreen()  // 게임 오버 UI
    {
        //.SetActive("false");~~
        Debug.Log("게임 오버 UI 표시");
    }
}


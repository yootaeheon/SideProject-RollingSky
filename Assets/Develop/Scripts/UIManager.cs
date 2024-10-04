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

   
  //  public void UpdateScoreUI()  //���� ���� ������Ʈ
  //  {
  //     
  //      Debug.Log("UI ������Ʈ: Gem : " + );
  //  }

   
    public void ShowGameOverScreen()  // ���� ���� UI
    {
        //.SetActive("false");~~
        Debug.Log("���� ���� UI ǥ��");
    }
}


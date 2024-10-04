using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int stageGem; //�� �������� ������ ȹ���� ���� ����
    public int totalGem; //�� ���� ����

    public bool isGameOver = false;

    private float startTime;
    private float elapsedTime;

   
    public float bestTime = float.MaxValue;   // �ִ� �ð� ��� 
                                              // ù �÷��̾� ��� = �ִ� �ð�

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

    public void StartGame() // ���� ���� ����
    {
        isGameOver = false;

        // ���� ���� �ð� ���
        startTime = Time.time;
    }

    public void GameOver()   // ���� ���� ����
    {
        isGameOver = true;

        // ���� ���� �� �ð� ���
        elapsedTime = Time.time - startTime;

        // �ִ� �ð� ����
        if (elapsedTime < bestTime)
        {
            bestTime = elapsedTime;
            Debug.Log("�ִ� ���! ���ο� ���: " + bestTime + "��");
        }
        else
        {
            Debug.Log("���� ����. �ҿ� �ð�: " + elapsedTime + "��");
        }
    }

    // �÷��̾ ������ ����� �� ȣ���ϴ� �Լ�
    public void AddGem(int GemCount)
    {
        if (!isGameOver)
        {
            stageGem += GemCount;
            totalGem += GemCount;
        }
    }
}
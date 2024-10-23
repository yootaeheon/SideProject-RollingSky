using System.Collections;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LSH_PlayerState : MonoBehaviour
{
    /* 
     * If you need, You can change this code to Singleton. �ʿ��Ͻø� �̱������� �����ϼŵ� �˴ϴ�!! 
     * It's not UI binding yet. ���� ������ ���ε��� ���� �ʾƼ� �����Ϳ��� ������ �����ؾ� �մϴ� �Ф� �˼��մϴ�!
     */

    [SerializeField] LSH_LoadingGame Canvas;

    enum PlayerState { Ready, Running, Pause, UnPause, Clear, Gameover, ReStart, Quit };
    [SerializeField] PlayerState playerState;

    [SerializeField] bool isDead;    // �÷��̾ �ǰ��� �Ծ��� ����Դϴٸ�, ���� ������� �ʾҽ��ϴ�.
    [SerializeField] bool isUnPause; //�Ͻ������� Ǯ������ 3�� ī������ ���� ��������ϴ�. �갡 T�� 
    [SerializeField] bool isMooJeok; //�÷��̾ �׾��ٰ� �̾��ϱ� �������� �Դϴ�. 3�ʵ��� �ƹ��� ������ �ǰ� �� ���� Ǯ���ϴ�.
    Coroutine unPauseRoutine;  // �Ͻ����� ������ 3��¥�� �ڷ�ƾ.
    Coroutine BuHwalRoutine;  // ���� �̾��ϱ�뵵 3��¥�� �ڷ�ƾ.

    [SerializeField] GameObject GameReadyUI;     //���� �������� ����߿� ��� ���ִ� UI
    [SerializeField] GameObject GameRunningUI;   //���� ���ۺ��� �����߿� ��� ���ִ� UI
    [SerializeField] TMP_Text GameprogressTMP;   //���� �����߿� ��� ���ִ� ����� �ۼ�Ʈ TMP
    [SerializeField] GameObject GamePauseUI;     //���� �߰��� ��� ����UI (�¿���)
    [SerializeField] TMP_Text GameUnPauseTMP;    //����UI�� ������ ���� 3��¥�� ī��Ʈ�ٿ� TMP
    [SerializeField] GameObject GameClearUI;     //���� Ŭ����� ��� UI (��ġ ������ ��� ������)
    [SerializeField] GameObject GameoverUI;      //���� �����ÿ� ��� UI (��ġ ������ ��� ������, �絵�� ����)
                                                 //�絵���� UI�� �����ϴ�. �׳� ��� ����ŸƮ ���¿��ٰ� �ٽ� ���׻��·� �ٲ�Ŷ󼭿�.. 

    /*
     * <�� ���� ����>
     * 
     * isDead:    �÷��̾� ����� ��Ȳ. (�갡 T��� �÷��̾� ���¸� ���ӿ����� ��ü��)
     * isUnPause: �Ͻ������� ���� ��Ȳ. (�갡 T��� 3�� ī��Ʈ�� ���۵�, �ڷ�ƾ ��)
     * isMooJeok: �÷��̾� ������ ��Ȳ. (�갡 T��� 3�ʵ��� ����, �ڷ�ƾ ��)
     * 
     * 
     * Ready:   ���� ������, �����. ���ӽð� ����. (��ġ �ѹ� �ϸ� ���ӽ��� UI�� ��ü)
     * 
     * Running:  ���ӽ��� ~ ������,    �ð� �帧.  (���ӽ��� �� �ð��� �帧�� ���� ���� ��ô���� ������ ���� %�� ǥ��.)
     * Pause:    ���� ��ư ��������,   �ð� ����.  (�Ͻ����� �˾� UI ����, ���� ��������)
     * UnPause:   �Ͻ��������� Ż���, �ð� �帧.  (�Ͻ����� �˾� UI ����, 3�ʵ��� ������ �����ְ� Ÿ�̸Ӹ� ������, 3�ʵ� ���� �簳)
     * 
     * Clear:    ���� Ŭ����,         �ð� ����.   (����Ŭ���� UI�� ��ü, ���� ����, ��ô�� 100% �޼����� ǥ��)      * 
     * Gameover: ���ӿ���,            �ð� ����.   (�絵�� ���ð���, �絵�� �̼��ý� ���ӿ��� UI ���)
     * ReStart:  ���� �̾��ϱ�,       �ð� �帧.   (�絵�� ���ý�. ��Ʈ 1�� �Ҹ� UI ��� �� ��¥��¥ 3�ʰ� �������� ���� �簳)
     *
     * Quit:     ���Ӿ� ��Ż,         �ð� ����.   (�Ͻ����� or ����Ŭ���� or ���ӿ����� ���� �� ��ư�� ������ �κ������ ������ ���϶�)
     *
     */




    private void Awake()
    {
        Debug.LogError("�ڷ�ƾ �ۼ������� �׽�Ʈ ���غþ��. ��ǻ�� ���� ����!"); // 181��° �ٿ��� �̾����ϴ�.
        Debug.LogWarning("���� �ǽôºе� ��Ŵٸ� \n 10, 81-82, 192��°�� �������ּŵ� �˴ϴ�");
        // 95��° ���� �̱��� �����Ϳ� ���� ��û,
        // 145��°, 230° ���� ��ɱ��� ��û�̰�,
        // �������� ���� �ڵ� �����̿���!!

    }

    private void Start()
    {
        //���� ���۽� Ready���·� ����
        playerState = PlayerState.Ready;
    }

    private void Update()
    {
        //���¸� ��� �����ؾ��ؼ� Update�� ���� ������,
        //�̺�Ʈ-�ݹ� �� ���·� �ٲ� �ʿ䰡 �ִٸ� �ǰ� �ֽðų�, ���� �ٲټŵ� �˴ϴ�!

        switch (playerState)
        {
            case PlayerState.Ready:
                //"�¿�� ��ũ���ϼ���" <-�̰� ��ư����, ��ư ������ playerState�� Running���� �Ѿ                
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
                //���� ���� �ð��� ���� �ۼ�Ʈ ������ �� (0 ~ 100 ���� ������ ������ ���� ǥ�õ�)
                GameReadyUI.SetActive(false);
                GameRunningUI.SetActive(true);                
                //GameprogressTMP.text = ""; 
                //Debug.LogWarning("�̱��濡�� ���� �ۼ������� ���� ��Ź�帳�ϴ�!");
                Time.timeScale = 1f;
                break;

            case PlayerState.Pause:
                //���� ��ư�� �������� �ߴ� UI�Դϴ�. �κ�� �����ų�, ������ �簳�� �� �ֽ��ϴ�.
                GamePauseUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case PlayerState.UnPause:
                //���� ��ư�� �����ٰ� ������ �簳�� ����Դϴ�. 3��¥�� ī��Ʈ�ٿ��� ǥ�õ˴ϴ�. (�Ҽ��� ù°�ڸ�����)
                GamePauseUI.SetActive(false);                
                isUnPause = true; //112��°�ٷ� �̾����ϴ�
                break;

            case PlayerState.Clear:
                //���� Ŭ����� �ش� �����̰� ���ɴϴٸ� ���� �������� �����ϴ�.. �׷��� �̱��� �̹����� ǥ���߾��..
                GameClearUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case PlayerState.Gameover:
                //���ӿ����� ������, ���� ���� or ���� �̾��ϱ⸦ �����Ҽ� �־��.
                GameoverUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case PlayerState.ReStart:
                //�׾��ٰ� ��Ȱ��ȸ�� ��� ���̺� ����Ʈ���� ���� �̾ �����ϴ� ����Դϴ�. (�̾��ϱ�)
                GameoverUI.SetActive(false);
                isDead = false;
                isMooJeok = true;
                break;

            case PlayerState.Quit:
                //���� ��Ȳ���� ������ �����ϰ� �κ�� ������ ����Դϴ�. �κ���� �ҷ��ɴϴ�.
                Canvas.GotoGame("LSH_Scene_Menu");
                break;


        }


        //�÷��̾� ������
        if (playerState == PlayerState.Running && isDead == true)
        {
            //�÷��̾� ������ ��� �Լ�
            PlayerDead();

        }



        //�Ͻ����� ������ �ڷ�ƾ
        if (isUnPause == true)
        {
            unPauseRoutine = StartCoroutine(CountDown(3.0f));
        }
        else if (unPauseRoutine != null && isUnPause == false)
        {

            //ī��Ʈ�ٿ� ���� �� ���� �簳
            StopCoroutine(unPauseRoutine);

        }



        //�̾��ϱ� ���ý� �ڷ�ƾ
        if (isMooJeok == true)
        {
            Time.timeScale = 1f;
            BuHwalRoutine = StartCoroutine(ReStartRoutine(3.0f));

        }
        else if (BuHwalRoutine != null && isMooJeok == false)
        {

            //���� �̾��ϱ� ���ý� �ο����� �����ð� ���� �� �Ϲ����� ���� ����
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
                //ī��Ʈ�ٿ� ���� �� ���� �簳                
                isUnPause = false;
                GameUnPauseTMP.text = "";
                playerState = PlayerState.Running;
                break;
            }

            //���ڰ� �پ��, �װ� ǥ������ -----> �ٵ� �̻��ϰ� �پ��......
            countDownNum -= 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            GameUnPauseTMP.text = (countDownNum).ToString("F1");

        }


    }



    public IEnumerator ReStartRoutine(float muJeckSiGan)
    {
        
        while (true)
        {
            Debug.Log("�÷��̾ ��½�Ÿ��� �������� ���������̿���.");
            //Debug.LogWarning("��� ���� ��Ź�帳�ϴ�!");

            if (muJeckSiGan <= 0f)
            {
                //�÷��̾� �������¸� �����ؿ�
                isMooJeok = false;
                playerState = PlayerState.Running;
                break;
            }

            //3�ʵ��� �÷��̾� ���� ���ڰ� �پ��, ǥ�����ʿ�X
            muJeckSiGan -= 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);

        }


    }



}

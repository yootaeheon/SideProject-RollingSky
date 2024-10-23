using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_PlayerState : MonoBehaviour
{
    enum PlayerState { Ready, Running, Pause, UnPause, Clear, Gameover, ReStart };
    [SerializeField] PlayerState playerState;
    [SerializeField] bool isDead;
    [SerializeField] bool isMooJeok;

    [SerializeField] GameObject GameReadyUI;     //���� �������� ����߿� ��� ���ִ� UI
    [SerializeField] GameObject GameRunningUI;   //���� ���ۺ��� �����߿� ��� ���ִ� UI
    [SerializeField] GameObject GameClearUI;     //���� Ŭ����� ��� UI (��ġ ������ ��� ������)
    [SerializeField] GameObject GameGameoverUI;  //���� �����ÿ� ��� UI (��ġ ������ ��� ������, �絵�� ����)
    [SerializeField] GameObject GamePauseUI;     //���� �߰��� ��� ����UI (�¿���)
    [SerializeField] GameObject GameUnPauseUI;   //����UI�� ������ ���� 3��¥�� ī��Ʈ�ٿ�
                                                 //�絵���� UI�� �����ϴ�. �׳� ��� ����ŸƮ ���¿��ٰ� �ٽ� ���׻��·� �ٲ�Ŷ󼭿�.. 

    /*
     * <�� ���� ����>
     * Ready:   ���� ������, �����. ���ӽð� ����. (��ġ �ѹ� �ϸ� ���ӽ��� UI�� ��ü)
     * 
     * Running:  ���ӽ��� ~ ������,    �ð� �帧.  (���ӽ��� �� �ð��� �帧�� ���� ���� ��ô���� ������ ���� %�� ǥ��.)
     * Pause:    ���� ��ư ��������,   �ð� ����.  (�Ͻ����� �˾� UI ����, ���� ��������)
     * UnPause:   �Ͻ��������� Ż���, �ð� �帧.  (�Ͻ����� �˾� UI ����, 3�ʵ��� ������ �����ְ� Ÿ�̸Ӹ� ������, 3�ʵ� ���� �簳)
     * 
     * Clear:    ���� Ŭ����,         �ð� ����.   (����Ŭ���� UI�� ��ü, ���� ����, ��ô�� 100% �޼����� ǥ��)      * 
     * Gameover: ���ӿ���,            �ð� ����.   (�絵�� ���ð���, �絵�� �̼��ý� ���ӿ��� UI ���)
     * ReStart:  ���� �����,         �ð� �帧.   (�絵�� ���ý�. ��Ʈ 1�� �Ҹ� UI ��� �� ��¥��¥ 3�ʰ� �������� ���� �簳)
     *
     *
     * �ʿ�������� �ִ� bool ����, �ϴ� ������
     * isPause:   �Ͻ������� ���� ��Ȳ. (�갡 T��� �÷��̾� ���¸� ����� ��ü��)
     * isDead:    �÷��̾� ����� ��Ȳ. (�갡 T��� �÷��̾� ���¸� ���ӿ����� ��ü��)
     * isMooJeok: �÷��̾� ������ ��Ȳ. (�갡 T��� 3�ʵڿ� ���ӽ���, 3�ʵ��� ����)
     */




    private void Awake()
    {
        Debug.LogError("��ũ��Ʈ �պ�����!!");
        Debug.LogError("���� bool�� �ٲܰԿ�!!");
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

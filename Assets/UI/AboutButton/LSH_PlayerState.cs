using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSH_PlayerState : MonoBehaviour
{
    enum PlayerState { Ready, Start, Pause, UnPause, Clear, Gameover };
    [SerializeField] bool isDead;
    [SerializeField] bool isMooJeok;

    /*
     * �� ���� ����
     * Ready:   ���� ������, ���� ����. �ð� ����. (��ġ �ѹ� �ϸ� ���ӽ��� UI�� ��ü)
     * 
     * Start:    ���� ���� ~ ������,  �ð� �帧.  (���ӽ��� �� �ð��� �帧�� ���� ���� ��ô���� ������ ���� %�� ǥ��.)
     * Pause:    ���� ��ư ��������,  �ð� ����.  (�Ͻ����� �˾� UI ����)
     * UnPause:   �Ͻ��������� Ż���, �ð� �帧.  (�Ͻ����� �˾� UI ����, ��� ����ٰ� ���� �ڷ�ƾ���� 3�ʵ� ���� �簳)
     * Clear:    ���� Ŭ����,        �׸���.     (����Ŭ���� UI�� ��ü, ���� ����, ��ô�� 100% �޼����� ǥ��) 
     * Gameover: ���ӿ���,           ���� ����.  (�絵�� ���ð���, �絵���� ��Ʈ 1�� �Ҹ��ϰ� �������� ���� �簳)
     * 
     *
     * isDead:    �÷��̾� ����� ��Ȳ. (�갡 T��� �÷��̾� ���¸� ���ӿ����� ��ü��)
     * isMooJeok: �÷��̾� ������ ��Ȳ. (�갡 T��� 3�ʵڿ� ����)
     */




    private void Awake()
    {
        Debug.LogError("��ũ��Ʈ �պ�����!!");
        Debug.LogError("���� bool�� �ٲܰԿ�!!");
        Debug.LogError("�������� ���� �簳�ϴ°� Resume State�� �ٲܰԿ�!!");
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

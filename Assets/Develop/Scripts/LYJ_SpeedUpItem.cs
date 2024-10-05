using System.Collections;
using UnityEngine;

public class LYJ_SpeedUpItem : MonoBehaviour
{
    [SerializeField] private float speedBoostAmount; //�ν�Ʈ �ӵ� ������
    [SerializeField] private float speedBoostDuration; //�ӵ� �ν�Ʈ ���� �ð�

    void OnTriggerEnter(Collider other)
    {
        //�浹�� ������Ʈ �±װ� Player�ΰ�?
        if (other.CompareTag("Player"))
        {
            //�浹�� ������Ʈ���� LYJ_PlayerMove ������Ʈ�� ������
            LYJ_PlayerMove playerMove = other.GetComponent<LYJ_PlayerMove>();

            if (playerMove != null)
            {
                StartCoroutine(SpeedBoostCoroutine(playerMove));
                Destroy(gameObject); //�浹������ ������ �ı�
            }
        }
    }

    //������ �ð� ���� �ӵ� �ν�Ʈ�� �����ϴ� �ڷ�ƾ
    private IEnumerator SpeedBoostCoroutine(LYJ_PlayerMove playerMove)
    {
        float originalSpeed = playerMove.GetMoveSpeed();

        //�ӵ� ����
        playerMove.SetMoveSpeed(originalSpeed * speedBoostAmount);

        //������ �ν�Ʈ ���� �ð���ŭ ���
        yield return new WaitForSeconds(speedBoostDuration);

        //�ν�Ʈ �� ���� �ӵ��� ����
        playerMove.SetMoveSpeed(originalSpeed);
    }
}

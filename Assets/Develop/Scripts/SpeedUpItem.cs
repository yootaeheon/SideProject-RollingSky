using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //�浹�� ������Ʈ �±װ� player�ΰ�?
        if (other.CompareTag("Player"))
        {
            //�浹�� ������Ʈ���� ������Ʈ�� ������
            //LYJ_PlayerMove ��ũ��Ʈ�� ApplySpeedBoost�� ����ϱ� ����
            LYJ_PlayerMove playerMove = other.GetComponent<LYJ_PlayerMove>();
            
            if (playerMove != null)
            {

                playerMove.ApplySpeedBoost();  //�÷��̾��� ApplySpeedBoost() �Լ��� ȣ���Ͽ� �ӵ� �ν�Ʈ�� ����
                Destroy(gameObject);//�浹������ ���� �Ŵϱ� ������ �ı�
            }
        }
    }
}

using UnityEngine;

public class LYJ_ShieldItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LYJ_PlayerMove playerMove = other.GetComponent<LYJ_PlayerMove>();

            if (playerMove != null)
            {
                //�÷��̾��� ���� �ڷ�ƾ�� ����
                playerMove.StartCoroutine(playerMove.ActivateShield());
            }

            Destroy(gameObject);
        }
    }
}

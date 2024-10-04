using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int GemCount;
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹�ߴ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // GameManager�� ������ ������Ŵ
            GameManager.Instance.AddGem(GemCount);

            // ������ ������Ʈ�� ����
            Destroy(gameObject);
        }
    }
}

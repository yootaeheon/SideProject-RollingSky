using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int GemCount;
    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌했는지 확인
        if (other.CompareTag("Player"))
        {
            // GameManager의 점수를 증가시킴
            GameManager.Instance.AddGem(GemCount);

            // 아이템 오브젝트를 없앰
            Destroy(gameObject);
        }
    }
}

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
                //플레이어의 쉴드 코루틴을 실행
                playerMove.StartCoroutine(playerMove.ActivateShield());
            }

            Destroy(gameObject);
        }
    }
}

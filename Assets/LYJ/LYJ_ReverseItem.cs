using System.Collections;
using UnityEngine;

public class LYJ_ReverseItem : MonoBehaviour
{
    private LYJ_PlayerMove playerMove;
    
    private bool isReversed = false;   //현재 좌우 반전 상태인가?

    [SerializeField] float reverseDuration = 5f; //방향 반전 지속 시간

    private void Start()
    {
        //PlayerMove 스크립트를 찾아 연결
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            playerMove = player.GetComponent<LYJ_PlayerMove>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //플레이어가 아이템에 닿으면 방향 반전
        if (other.CompareTag("Player") && !isReversed)
        {
            if (playerMove != null)
            {
                StartCoroutine(ReverseControlCoroutine());
                Destroy(gameObject);
            }   
        }
    }

    //좌우 방향을 5초 동안 반전
    private IEnumerator ReverseControlCoroutine()
    {
        isReversed = true;

        //좌우 방향 반전
        playerMove.ReverseControls(true);

        yield return new WaitForSeconds(reverseDuration);

        //원래 방향으로 되돌림
        playerMove.ReverseControls(false);

        isReversed = false;
    }
}

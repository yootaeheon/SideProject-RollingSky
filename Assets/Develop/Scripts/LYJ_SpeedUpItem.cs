using System.Collections;
using UnityEngine;

public class LYJ_SpeedUpItem : MonoBehaviour
{
    [SerializeField] private float speedBoostAmount; //부스트 속도 증가량
    [SerializeField] private float speedBoostDuration; //속도 부스트 지속 시간

    void OnTriggerEnter(Collider other)
    {
        //충돌한 오브젝트 태그가 Player인가?
        if (other.CompareTag("Player"))
        {
            //충돌한 오브젝트에서 LYJ_PlayerMove 컴포넌트를 가져옴
            LYJ_PlayerMove playerMove = other.GetComponent<LYJ_PlayerMove>();

            if (playerMove != null)
            {
                StartCoroutine(SpeedBoostCoroutine(playerMove));
                Destroy(gameObject); //충돌했으면 아이템 파괴
            }
        }
    }

    //정해진 시간 동안 속도 부스트를 적용하는 코루틴
    private IEnumerator SpeedBoostCoroutine(LYJ_PlayerMove playerMove)
    {
        float originalSpeed = playerMove.GetMoveSpeed();

        //속도 증가
        playerMove.SetMoveSpeed(originalSpeed * speedBoostAmount);

        //지정한 부스트 지속 시간만큼 대기
        yield return new WaitForSeconds(speedBoostDuration);

        //부스트 후 원래 속도로 복귀
        playerMove.SetMoveSpeed(originalSpeed);
    }
}

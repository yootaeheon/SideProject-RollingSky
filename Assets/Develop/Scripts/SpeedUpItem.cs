using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //충돌한 오브젝트 태그가 player인가?
        if (other.CompareTag("Player"))
        {
            //충돌한 오브젝트에서 컴포넌트를 가져옴
            //LYJ_PlayerMove 스크립트의 ApplySpeedBoost를 사용하기 위해
            LYJ_PlayerMove playerMove = other.GetComponent<LYJ_PlayerMove>();
            
            if (playerMove != null)
            {

                playerMove.ApplySpeedBoost();  //플레이어의 ApplySpeedBoost() 함수를 호출하여 속도 부스트를 적용
                Destroy(gameObject);//충돌했으면 먹은 거니까 아이템 파괴
            }
        }
    }
}

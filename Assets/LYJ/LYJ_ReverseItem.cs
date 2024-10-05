using System.Collections;
using UnityEngine;

public class LYJ_ReverseItem : MonoBehaviour
{
    private LYJ_PlayerMove playerMove;
    
    private bool isReversed = false;   //���� �¿� ���� �����ΰ�?

    [SerializeField] float reverseDuration = 5f; //���� ���� ���� �ð�

    private void Start()
    {
        //PlayerMove ��ũ��Ʈ�� ã�� ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            playerMove = player.GetComponent<LYJ_PlayerMove>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //�÷��̾ �����ۿ� ������ ���� ����
        if (other.CompareTag("Player") && !isReversed)
        {
            if (playerMove != null)
            {
                StartCoroutine(ReverseControlCoroutine());
                Destroy(gameObject);
            }   
        }
    }

    //�¿� ������ 5�� ���� ����
    private IEnumerator ReverseControlCoroutine()
    {
        isReversed = true;

        //�¿� ���� ����
        playerMove.ReverseControls(true);

        yield return new WaitForSeconds(reverseDuration);

        //���� �������� �ǵ���
        playerMove.ReverseControls(false);

        isReversed = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class YTH_PlayerPresenter : MonoBehaviour
{
    [SerializeField] YTH_PlayerModel playerModel;

    [SerializeField] TextMeshProUGUI stageGemText; //TextMeshPro�� text ����
    [SerializeField] TextMeshProUGUI totalGemText;

    [SerializeField] GameObject Gem; 

    private void UpdateStageGem(int stageGem)
    {
        stageGemText.text = $"{stageGem}";
    }
    private void UpdateTotalGem(int totalGem)
    {
        totalGemText.text = $"{totalGem}";
    }



    private void OnEnable()
    {
        playerModel.OnStageGemChanged += UpdateStageGem;
        playerModel.OnTotalGemChanged += UpdateTotalGem;
    }

    private void OnDisable()
    {
        playerModel.OnStageGemChanged -= UpdateStageGem;
        playerModel.OnTotalGemChanged -= UpdateTotalGem;
    }

    private void Start()
    {
        UpdateStageGem(playerModel.StageGem);
        UpdateTotalGem(playerModel.TotalGem);
    }


    //������ ��ũ��Ʈ�� ���� ���� �ÿ� ����
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Gem")) //������ Gem �̶�� �±׷� �з�
        {
            Destroy(other.gameObject);
            playerModel.StageGem ++;             //���� �� ���� ������Ʈ�� ������ ������Ʈ �ı��� ���ÿ� ī��Ʈ +1
            playerModel.TotalGem ++;
        }
    }


}

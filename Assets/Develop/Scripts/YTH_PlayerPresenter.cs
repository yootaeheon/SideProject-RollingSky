using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class YTH_PlayerPresenter : MonoBehaviour
{
    [SerializeField] YTH_PlayerModel playerModel;

    [SerializeField] TextMeshProUGUI stageGemText; //TextMeshPro로 text 생성
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


    //아이템 스크립트가 따로 있을 시에 수정
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Gem")) //보석은 Gem 이라는 태그로 분류
        {
            Destroy(other.gameObject);
            playerModel.StageGem ++;             //게임 중 보석 오브젝트와 닿으면 오브젝트 파괴와 동시에 카운트 +1
            playerModel.TotalGem ++;
        }
    }


}

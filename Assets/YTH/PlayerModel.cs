using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] int stageGem;
    public int StageGem { get { return stageGem; } set { stageGem = value; OnStageGemChanged?.Invoke(stageGem); } }
    public UnityAction<int> OnStageGemChanged;

    [SerializeField] int totalGem;
    public int TotalGem { get { return totalGem; } set { totalGem = value; OnTotalGemChanged?.Invoke(totalGem); } }
    public UnityAction OnTotalGemChanged;
}

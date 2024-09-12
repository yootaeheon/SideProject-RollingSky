using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int stageGem; //ÇÑ ½ºÅ×ÀÌÁö ³»¿¡¼­ È¹µæÇÑ º¸¼® °¹¼ö
    public int totalGem; //ÃÑ º¸¼® °¹¼ö

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }

}

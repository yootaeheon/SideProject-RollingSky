using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSH_LoadingGame : MonoBehaviour
{
    
    // 얘네로 게임1씬 게임2씬 로딩창 둘 다 우려먹을거에요
    [SerializeField] GameObject loadImg;
    [SerializeField] TMP_Text loadTxt;


    private void Start()
    {
        loadImg.SetActive(false);

    }


    //버튼 이벤트
    public void GotoGame(string sceneName)
    {

        //로딩 시작시부터 이미지와 텍스트를 보여줌
        loadImg.SetActive(true);

        // 연결할 씬 이름을 괄호 안에 직접 넣어서 수정 가능
        ChangeScene(sceneName); //LSH_Scene_Game2를 이벤트맵으로 취급함

    }


    public void ChangeScene(string sceneNum)
    {

        if (loadingRoutine != null)
            return;

        loadingRoutine = StartCoroutine(LoadingRoutine(sceneNum));
    }

    Coroutine loadingRoutine;

    IEnumerator LoadingRoutine(string sceneName)
    {

        // 몇퍼 진행됐는지, 씬 넘어갈 타이밍 어떻게 할지 제어하기 위해 변수로 선언
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);

        //allowSceneActivation을 false로 두어서 씬 전환을 즉시 하지않고 대기하게 만듦
        oper.allowSceneActivation = false;
        

        while (oper.isDone == false)
        {
            if (oper.progress < 0.9f)
            {
                //아직 로딩중...
                Debug.Log($"아직 로딩중, 진척도 = {oper.progress}");
            }
            else
            {
                //0.9가 넘어갔다면, 로딩이 다 됐다고 생각해도 무방함
                Debug.Log("로딩 완료됨");

                break;

            }
            yield return null;
        }


        Debug.Log("로딩바 억지로 천천히 채우는중. \n 다 채워지면 알아서 넘어갑니다!");
        float time = 0f;
        while (time < 100f)
        {
            time += 1f;
            string percent = ((int)time).ToString();
            loadTxt.text = $"{percent}%";
            yield return null;
        }

        while (Input.anyKeyDown != false)
        {
            yield return null;
        }

        oper.allowSceneActivation = true;


        //if (Input.anyKeyDown)
        //{
        //    
        //    //SceneManager.LoadScene("LSH_Scene_Menu"); // 동기
        //    SceneManager.LoadSceneAsync("LSH_Scene_Menu"); // 비동기


        //}

    }


}

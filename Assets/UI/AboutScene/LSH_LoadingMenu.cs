using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class LSH_LoadingMenu : MonoBehaviour
{

    [SerializeField] Slider loadSli;

    private void Start()
    {
        // 연결할 씬 이름을 괄호 안에 직접 넣어서 수정 가능
        ChangeScene("LSH_Scene_Menu");
    }
    public void ChangeScene(string sceneNum)
    {
        // 비동기식 로딩
        //SceneManager.LoadSceneAsync(sceneNum);

        // 로딩 률 보여주기
        //AsyncOperation oper = SceneManager.LoadSceneAsync(sceneNum);


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
        //로딩 시작시부터 이미지와 슬라이드를 보여줌
        loadSli.gameObject.SetActive(true);

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
        while (time < 5f)
        {
            time += Time.deltaTime;
            loadSli.value = time / 5f;
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

/*
 

public class NewBehaviourScript : MonoBehaviour
{

    public string name;


    void Start()
    {
        // 코루틴 (동기) ---------------> 유니티 안에서 관리됨, 순서대로 돌음
        //StartCoroutine(Routine());

        // 쓰레드 (비동기, Task 이용) ---> 유니티 안에서 관리 X, 지 멋대로 알아서 돌음
        Task.Run(ThreadFunc);
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{name} 업데이트");

    }


    // 코루틴
    //IEnumerator Routine()
    //{
    //    while (true)
    //    {
    //        yield return null;
    //        Debug.Log($"{name} 코루틴");
    //    }
    //}
    

    //쓰레드
    private void ThreadFunc()
    {
        for(int i=0; i<100; i++)
        {
            Debug.Log($"{name} 쓰레드 {i}");
        }
    }


}


--------------------------------------------

    // 기존의 SceneManager.LoadScene은 로딩이 다 되자마자 넘어가는 방식인데,
    // 동기식이기 때문에 로딩 진행하는 동안 게임이 멈춰있게 되어 사용자 경험에 지장을 줌
    // 따라서, 로딩은 비동기식인 쓰레드를 이용해서 로드를 따로 진행하는 것이기 때문에
    // 게임이 돌아가면서도 로딩이 가능함, 그 진행도를 보여주는것이 로딩 스크롤Bar임!!!




 */

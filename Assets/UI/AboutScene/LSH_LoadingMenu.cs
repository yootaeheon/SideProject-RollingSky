using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LSH_LoadingMenu : MonoBehaviour
{
    [SerializeField] Image loadImg;
    [SerializeField] Slider loadSli;

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
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);

        oper.allowSceneActivation = false;
        loadImg.gameObject.SetActive(true);
        loadSli.gameObject.SetActive(true);

        while (oper.isDone == false)
        {
            if (oper.progress < 0.9f)
            {
                //아직 로딩중...
                Debug.Log($"loading = {oper.progress}");
                loadSli.value = oper.progress;
            }
            else
            {
                //0.9가 넘어갔다면, 로딩이 다 됐다고 생각해도 무방함
                Debug.Log("로딩 완료");
                break;

            }
            yield return null;
        }

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
        loadImg.gameObject.SetActive(false);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }

    }

}

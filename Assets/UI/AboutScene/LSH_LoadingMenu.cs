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
        // �񵿱�� �ε�
        //SceneManager.LoadSceneAsync(sceneNum);

        // �ε� �� �����ֱ�
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
                //���� �ε���...
                Debug.Log($"loading = {oper.progress}");
                loadSli.value = oper.progress;
            }
            else
            {
                //0.9�� �Ѿ�ٸ�, �ε��� �� �ƴٰ� �����ص� ������
                Debug.Log("�ε� �Ϸ�");
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

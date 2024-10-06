using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSH_LoadingGame : MonoBehaviour
{
    
    // ��׷� ����1�� ����2�� �ε�â �� �� ��������ſ���
    [SerializeField] GameObject loadImg;
    [SerializeField] TMP_Text loadTxt;


    private void Start()
    {
        loadImg.SetActive(false);

    }


    //��ư �̺�Ʈ
    public void GotoGame(string sceneName)
    {

        //�ε� ���۽ú��� �̹����� �ؽ�Ʈ�� ������
        loadImg.SetActive(true);

        // ������ �� �̸��� ��ȣ �ȿ� ���� �־ ���� ����
        ChangeScene(sceneName); //LSH_Scene_Game2�� �̺�Ʈ������ �����

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

        // ���� ����ƴ���, �� �Ѿ Ÿ�̹� ��� ���� �����ϱ� ���� ������ ����
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);

        //allowSceneActivation�� false�� �ξ �� ��ȯ�� ��� �����ʰ� ����ϰ� ����
        oper.allowSceneActivation = false;
        

        while (oper.isDone == false)
        {
            if (oper.progress < 0.9f)
            {
                //���� �ε���...
                Debug.Log($"���� �ε���, ��ô�� = {oper.progress}");
            }
            else
            {
                //0.9�� �Ѿ�ٸ�, �ε��� �� �ƴٰ� �����ص� ������
                Debug.Log("�ε� �Ϸ��");

                break;

            }
            yield return null;
        }


        Debug.Log("�ε��� ������ õõ�� ä�����. \n �� ä������ �˾Ƽ� �Ѿ�ϴ�!");
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
        //    //SceneManager.LoadScene("LSH_Scene_Menu"); // ����
        //    SceneManager.LoadSceneAsync("LSH_Scene_Menu"); // �񵿱�


        //}

    }


}

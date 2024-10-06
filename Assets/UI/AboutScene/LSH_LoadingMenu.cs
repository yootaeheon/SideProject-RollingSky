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
        // ������ �� �̸��� ��ȣ �ȿ� ���� �־ ���� ����
        ChangeScene("LSH_Scene_Menu");
    }
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

        // ���� ����ƴ���, �� �Ѿ Ÿ�̹� ��� ���� �����ϱ� ���� ������ ����
        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);

        //allowSceneActivation�� false�� �ξ �� ��ȯ�� ��� �����ʰ� ����ϰ� ����
        oper.allowSceneActivation = false;
        //�ε� ���۽ú��� �̹����� �����̵带 ������
        loadSli.gameObject.SetActive(true);

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
        //    //SceneManager.LoadScene("LSH_Scene_Menu"); // ����
        //    SceneManager.LoadSceneAsync("LSH_Scene_Menu"); // �񵿱�

            
        //}

    }

}

/*
 

public class NewBehaviourScript : MonoBehaviour
{

    public string name;


    void Start()
    {
        // �ڷ�ƾ (����) ---------------> ����Ƽ �ȿ��� ������, ������� ����
        //StartCoroutine(Routine());

        // ������ (�񵿱�, Task �̿�) ---> ����Ƽ �ȿ��� ���� X, �� �ڴ�� �˾Ƽ� ����
        Task.Run(ThreadFunc);
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{name} ������Ʈ");

    }


    // �ڷ�ƾ
    //IEnumerator Routine()
    //{
    //    while (true)
    //    {
    //        yield return null;
    //        Debug.Log($"{name} �ڷ�ƾ");
    //    }
    //}
    

    //������
    private void ThreadFunc()
    {
        for(int i=0; i<100; i++)
        {
            Debug.Log($"{name} ������ {i}");
        }
    }


}


--------------------------------------------

    // ������ SceneManager.LoadScene�� �ε��� �� ���ڸ��� �Ѿ�� ����ε�,
    // ������̱� ������ �ε� �����ϴ� ���� ������ �����ְ� �Ǿ� ����� ���迡 ������ ��
    // ����, �ε��� �񵿱���� �����带 �̿��ؼ� �ε带 ���� �����ϴ� ���̱� ������
    // ������ ���ư��鼭�� �ε��� ������, �� ���൵�� �����ִ°��� �ε� ��ũ��Bar��!!!




 */

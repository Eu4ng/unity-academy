using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    public string m_LoadingSceneName = "Loading";

    // Unity Event Inspector�� ����ϱ� ���� �뵵
    public static void ChangeScene(string _nextSceneName)
    {
        SceneLoader.Get().ChangeScene(_nextSceneName); // StartCoroutine�� static �޼ҵ尡 �ƴϱ� ������ �̷��� ���
    }
    public void ChangeScene(string _nextSceneName, float _refreshCycleTime = 0.5f, float _waitingTime = 1f)
    {
        ChangeScene(_nextSceneName, m_LoadingSceneName, _refreshCycleTime, _waitingTime);
    }
    public void ChangeScene(string _nextSceneName, string _loadingSceneName, float _refreshCycleTime = 0.5f, float _waitingTime = 1f)
    {
        StartCoroutine(Loading(_nextSceneName, _loadingSceneName, _refreshCycleTime, _waitingTime));
    }

    IEnumerator Loading(string _nextSceneName, string _loadingSceneName, float _refreshCycleTime, float _waitingTime)
    {
        yield return SceneManager.LoadSceneAsync(_loadingSceneName);
        AsyncOperation op = SceneManager.LoadSceneAsync(_nextSceneName);
        
        // �ε����� �� Ȱ��ȭ ����
        op.allowSceneActivation = false;

        // �ε��߿� ������ ������ �����̴��� 1��������
        Slider slider = FindObjectOfType<Slider>();

        while (!op.isDone)
        {
            slider.value = op.progress / 0.9f; // op.progress max ���� 0.9f

            // �ε��� �Ϸ�Ǹ� ��� �� �� ��ȯ
            if (Mathf.Approximately(slider.value, 1f))
            {
                yield return new WaitForSeconds(_waitingTime);    // ������ ���� ���� �����̸� ��
                op.allowSceneActivation = true;
            }
            // �ε��� ���� �ֱ�
            yield return new WaitForSeconds(_refreshCycleTime);  // ������ ���� ���� �����̸� ��
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string _nextSceneName, string _loadingSceneName, float _refreshCycleTime = 0.5f, float _waitingTime = 1f)
    {
        StartCoroutine(Loading(_nextSceneName, _loadingSceneName, _refreshCycleTime, _waitingTime));
    }

    IEnumerator Loading(string _nextSceneName, string _loadingSceneName, float _refreshCycleTime, float _waitingTime)
    {
        yield return SceneManager.LoadSceneAsync(_loadingSceneName);
        AsyncOperation op = SceneManager.LoadSceneAsync(_nextSceneName);
        
        // 로딩중인 씬 활성화 금지
        op.allowSceneActivation = false;

        // 로딩중에 보여줄 씬에는 슬라이더가 1개여야함
        Slider slider = FindObjectOfType<Slider>();

        while (!op.isDone)
        {
            slider.value = op.progress / 0.9f; // op.progress max 값이 0.9f

            // 로딩이 완료되면 잠시 후 씬 전환
            if (Mathf.Approximately(slider.value, 1f))
            {
                yield return new WaitForSeconds(_waitingTime);    // 눈으로 보기 위해 딜레이를 줌
                op.allowSceneActivation = true;
            }
            // 로딩율 갱신 주기
            yield return new WaitForSeconds(_refreshCycleTime);  // 눈으로 보기 위해 딜레이를 줌
        }
    }
}

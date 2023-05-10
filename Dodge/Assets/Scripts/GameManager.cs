using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임 정보
    bool IsGameOver = false;
    GameObject player;

    // 게임 기록
    float bestRecord = 0;
    float survivalTime = 0;

    // 게임 난이도
    int level = 0;

    // 게임 오버 화면
    public GameObject gameoverText;
    public Text bestRecordText;
    public Text survivalTimeText;

    void Awake()
    {
        Load();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        survivalTime = 0;
    }

    void Update()
    {
        // 게임 오버 확인
        if(!player.activeSelf)
            EndGame();

        if(IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                StartGame();

            return;
        }
        
        // Survival Time 기록 및 표시
        survivalTime += Time.deltaTime;
        if(survivalTimeText)
            survivalTimeText.text = "Time : " + Mathf.Floor(survivalTime * 100f) / 100f;
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    void EndGame()
    {
        // 기록 업데이트
        IsGameOver = true;
        if (survivalTime >= bestRecord)
            bestRecord = survivalTime;

        if (bestRecordText)
            bestRecordText.text = "Best Record : " + Mathf.Floor(bestRecord * 100f) / 100f;

        // 기록 저장
        Save();

        // 게임 오버 화면 출력
        gameoverText.SetActive(true);
    }

    void Save()
    {
        PlayerPrefs.SetFloat("bestRecord", bestRecord);
    }

    void Load()
    {
        bestRecord = PlayerPrefs.GetFloat("bestRecord");
    }
}

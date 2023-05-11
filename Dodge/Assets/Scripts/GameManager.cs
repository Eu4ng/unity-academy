using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���� ����
    bool IsGameOver = false;
    GameObject player;

    // ���� ���
    float bestRecord = 0;
    float survivalTime = 0;

    // ���� ���̵�
    int level = 0;

    // ���� ���� ȭ��
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
        // ���� ���� Ȯ��
        if(!player.activeSelf)
            EndGame();

        if(IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                StartGame();

            return;
        }
        
        // Survival Time ��� �� ǥ��
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
        // ��� ������Ʈ
        IsGameOver = true;
        if (survivalTime >= bestRecord)
            bestRecord = survivalTime;

        if (bestRecordText)
            bestRecordText.text = "Best Record : " + Mathf.Floor(bestRecord * 100f) / 100f;

        // ��� ����
        Save();

        // ���� ���� ȭ�� ���
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

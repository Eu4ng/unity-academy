using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameover = false;
    public Text ScoreText;
    public GameObject GameoverUI;

    int m_Score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // 게임오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (IsGameover && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int _newScore)
    {
        if(!IsGameover)
        {
            m_Score += _newScore;
            ScoreText.text = "Score : " + m_Score;
        }
    }
    
    public void OnPlayerDead()
    {
        IsGameover = true;
        GameoverUI.SetActive(true);
    }
}

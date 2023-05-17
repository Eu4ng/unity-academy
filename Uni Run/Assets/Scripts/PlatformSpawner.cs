using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // 발판
    public GameObject PlatformPrefab;
    public int Count = 3;

    // 배치 간격
    public float TimeBetSpawnMin = 1.25f;
    public float TimeBetSpawnMax = 2.25f;
    float m_TimeBetSpawn;

    public float MinY = -3.5f;
    public float MaxY = 1.5f;
    float m_PosX = 20f;

    GameObject[] m_Platforms;
    int m_CurrentIndex = 0;

    Vector2 m_PoolPosition = new Vector2(0, -25);
    float m_LastSpawnTime;

    private void Start()
    {
        // 변수를 초기화하고 사용할 발판을 미리 생성
        m_Platforms = new GameObject[Count];

        for (int i = 0; i < Count; i++)
            m_Platforms[i] = Instantiate(PlatformPrefab, m_PoolPosition, Quaternion.identity);

        m_LastSpawnTime = 0f;
        m_TimeBetSpawn = 0f;
    }

    private void Update()
    {
        // 게임오버 상태에서는 동작하지 않음
        if (GameManager.Instance.IsGameover)
            return;

        // m_TimeBetSpawn 초 마다 발판 재배치
        if (Time.time >= m_LastSpawnTime + m_TimeBetSpawn)
        {
            m_LastSpawnTime = Time.time;
            m_TimeBetSpawn = Random.Range(TimeBetSpawnMin, TimeBetSpawnMax);
            float posY = Random.Range(MinY, MaxY);

            // 발판 초기화
            m_Platforms[m_CurrentIndex].SetActive(false);
            m_Platforms[m_CurrentIndex].SetActive(true);

            // 화면 오른쪽에 발판 재배치
            m_Platforms[m_CurrentIndex].transform.position = new Vector2(m_PosX, posY);

            m_CurrentIndex++;
            if (m_CurrentIndex >= Count)
                m_CurrentIndex = 0;
        }

    }
}

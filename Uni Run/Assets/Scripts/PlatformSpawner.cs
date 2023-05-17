using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // ����
    public GameObject PlatformPrefab;
    public int Count = 3;

    // ��ġ ����
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
        // ������ �ʱ�ȭ�ϰ� ����� ������ �̸� ����
        m_Platforms = new GameObject[Count];

        for (int i = 0; i < Count; i++)
            m_Platforms[i] = Instantiate(PlatformPrefab, m_PoolPosition, Quaternion.identity);

        m_LastSpawnTime = 0f;
        m_TimeBetSpawn = 0f;
    }

    private void Update()
    {
        // ���ӿ��� ���¿����� �������� ����
        if (GameManager.Instance.IsGameover)
            return;

        // m_TimeBetSpawn �� ���� ���� ���ġ
        if (Time.time >= m_LastSpawnTime + m_TimeBetSpawn)
        {
            m_LastSpawnTime = Time.time;
            m_TimeBetSpawn = Random.Range(TimeBetSpawnMin, TimeBetSpawnMax);
            float posY = Random.Range(MinY, MaxY);

            // ���� �ʱ�ȭ
            m_Platforms[m_CurrentIndex].SetActive(false);
            m_Platforms[m_CurrentIndex].SetActive(true);

            // ȭ�� �����ʿ� ���� ���ġ
            m_Platforms[m_CurrentIndex].transform.position = new Vector2(m_PosX, posY);

            m_CurrentIndex++;
            if (m_CurrentIndex >= Count)
                m_CurrentIndex = 0;
        }

    }
}

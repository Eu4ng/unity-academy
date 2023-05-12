using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 메테오 설정
    [Header("Meteorite")]
    public GameObject meteorite;
    public float meteoriteWidth = 1;
    int maxSpawnCounts;

    // 스폰 설정
    [Header("Spawn")]
    public Vector2 spawnCenter;
    public float width = 1;
    public float margin;
    [Space(10f)]
    public float minSpawnTime = 1;
    public float maxSpawnTime = 1;
    float spawnCoolTime;
    float spawnTimer = 0;

    List<Vector2> spawnPositions = new List<Vector2>();

    private void Awake()
    {
        SetSpawnCoolTime();
        CalculateSpawnPositions();
    }

    private void Update()
    {
        CheckSpawnTimer();
    }

    void SetSpawnCoolTime()
    {
        spawnCoolTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void CheckSpawnTimer()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCoolTime)
        {
            SpawnMeteorites();

            // 스폰 세팅 초기화
            spawnTimer = 0;
            SetSpawnCoolTime();
        }
    }
    void SpawnMeteorites()
    {
        // 스폰시킬 랜덤 위치 선택
        List<int> indices = new List<int>();
        GetRandomIndices(ref indices);

        // 메테오 스폰
        foreach(int index in indices)
        {
            Instantiate(meteorite, spawnPositions[index], Quaternion.Euler(Vector2.zero));
        }
    }
    void CalculateSpawnPositions()
    {
        // Spawn Count 계산
        maxSpawnCounts = (int)(width / meteoriteWidth);
        float spawnWidth = meteoriteWidth * maxSpawnCounts;

        // Spawn Count 오류
        if (maxSpawnCounts <= 0)
        {
            print("Max Spawn Counts <= 0");
            return;
        }

        // Spawn Positions 계산
        Vector2 initPosition = new Vector2((spawnCenter.x - (spawnWidth / 2)) + (meteoriteWidth / 2), spawnCenter.y);
        for (int i = 0; i < maxSpawnCounts; i++)
        {
            spawnPositions.Add(initPosition + (i * new Vector2(meteoriteWidth, 0)));
        }
    }
    
    // 유틸리티
    void GetRandomIndices(ref List<int> indices)
    {
        int spawnCount = Random.Range(1, maxSpawnCounts); // 최소 1개의 메테오가 소환되어야하고, 피할 곳 역시 최소한 1곳이 존재해야함
        int count = 0;

        int index;
        while(count < spawnCount)
        {
            index = Random.Range(0, maxSpawnCounts);

            if(!indices.Contains(index))
            {
                indices.Add(index);
                count++;
            }
        }
    }
}

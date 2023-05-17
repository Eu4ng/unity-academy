using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ���׿� ����
    [Header("Meteorite")]
    public GameObject meteorite;
    public float meteoriteWidth = 1;
    int maxSpawnCounts;

    // ���� ����
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

            // ���� ���� �ʱ�ȭ
            spawnTimer = 0;
            SetSpawnCoolTime();
        }
    }
    void SpawnMeteorites()
    {
        // ������ų ���� ��ġ ����
        List<int> indices = new List<int>();
        GetRandomIndices(ref indices);

        // ���׿� ����
        foreach(int index in indices)
        {
            Instantiate(meteorite, spawnPositions[index], Quaternion.Euler(Vector2.zero));
        }
    }
    void CalculateSpawnPositions()
    {
        // Spawn Count ���
        maxSpawnCounts = (int)(width / meteoriteWidth);
        float spawnWidth = meteoriteWidth * maxSpawnCounts;

        // Spawn Count ����
        if (maxSpawnCounts <= 0)
        {
            print("Max Spawn Counts <= 0");
            return;
        }

        // Spawn Positions ���
        Vector2 initPosition = new Vector2((spawnCenter.x - (spawnWidth / 2)) + (meteoriteWidth / 2), spawnCenter.y);
        for (int i = 0; i < maxSpawnCounts; i++)
        {
            spawnPositions.Add(initPosition + (i * new Vector2(meteoriteWidth, 0)));
        }
    }
    
    // ��ƿ��Ƽ
    void GetRandomIndices(ref List<int> indices)
    {
        int spawnCount = Random.Range(1, maxSpawnCounts); // �ּ� 1���� ���׿��� ��ȯ�Ǿ���ϰ�, ���� �� ���� �ּ��� 1���� �����ؾ���
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

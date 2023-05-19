using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] List<GameObject> backgrounds;

    [SerializeField] float speed = 8f;
    float height = 16;
    float m_Distance = 0;
    int backGroundIndex;
    int BackGroundIndex
    {
        get => backGroundIndex;
        set
        {
            if (value >= backgrounds.Count)
                backGroundIndex = 0;
            else
                backGroundIndex = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 배경 이동
        float translation = speed * Time.deltaTime;
        foreach (GameObject background in backgrounds)
        {
            background.transform.Translate(Vector2.down * translation);
        }

        // 이동 거리 기록
        m_Distance += translation;
        if (m_Distance >= height)
        {
            ResetPosition(BackGroundIndex);
            BackGroundIndex++;
            m_Distance = 0;
        }
        PointManager.Get().Distance += translation;
    }

    void ResetPosition(int index)
    {
        backgrounds[index].transform.position += new Vector3(0, height * backgrounds.Count, 0);
    }
}

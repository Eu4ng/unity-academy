using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] List<GameObject> backgrounds;

    [SerializeField] float speed = 8f;
    float height = 16;
    float distance = 0;
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
        distance += translation;
        if (distance >= height)
        {
            ResetPosition(BackGroundIndex);
            BackGroundIndex++;
            distance = 0;
        }
    }

    void ResetPosition(int index)
    {
        backgrounds[index].transform.position += new Vector3(0, height * backgrounds.Count, 0);
    }
}

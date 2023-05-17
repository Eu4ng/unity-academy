using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] Obstacles;
    bool m_Stepped = false;

    private void OnEnable()
    {
        // 발판을 리셋하는 처리
        m_Stepped = false;

        foreach(var obstacle in Obstacles)
        {
            if (Random.Range(0, 3) == 0)
                obstacle.SetActive(true);
            else
                obstacle.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
        if(collision.collider.CompareTag("Player") && !m_Stepped)
        {
            m_Stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
}

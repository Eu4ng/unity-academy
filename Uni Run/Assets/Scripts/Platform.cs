using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] Obstacles;
    bool m_Stepped = false;

    private void OnEnable()
    {
        // ������ �����ϴ� ó��
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
        // �÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
        if(collision.collider.CompareTag("Player") && !m_Stepped)
        {
            m_Stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
}

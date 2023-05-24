using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class BulletActor : MonoBehaviour
{
    // ��� ����
    IObjectPool<GameObject> m_BulletPool;
    bool m_Collided = false;

    private void OnEnable()
    {
        m_Collided = false;
    }
    private void Start()
    {
        GameObjectPoolTracker gameObjectPoolTracker = GetComponent<GameObjectPoolTracker>();
        if(gameObjectPoolTracker != null) m_BulletPool = gameObjectPoolTracker.Pool;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // �� ���� �浹 ó��
        if (m_Collided) return;
        else m_Collided = true;

        // ������ ���� �� �ı�
        GetComponent<AbilityEffect>().ApplyEffect(collision.gameObject);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (m_BulletPool == null) Destroy(gameObject);
        else m_BulletPool.Release(gameObject);
    }
}

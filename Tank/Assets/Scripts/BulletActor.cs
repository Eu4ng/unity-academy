using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class BulletActor : MonoBehaviour
{
    // 멤버 변수
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
        // 한 번만 충돌 처리
        if (m_Collided) return;
        else m_Collided = true;

        // 데미지 가한 후 파괴
        GetComponent<AbilityEffect>().ApplyEffect(collision.gameObject);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (m_BulletPool == null) Destroy(gameObject);
        else m_BulletPool.Release(gameObject);
    }
}

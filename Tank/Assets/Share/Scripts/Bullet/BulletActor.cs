using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class BulletActor : MonoBehaviour
{
    // ¸â¹ö º¯¼ö
    IObjectPool<GameObject> m_BulletPool;

    private void Start()
    {
        m_BulletPool = GetComponent<GameObjectPoolTracker>().Pool;
        if (m_BulletPool == null)
            Debug.Log("No BulletPool");
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (m_BulletPool == null) Destroy(gameObject);
        else m_BulletPool.Release(gameObject);
    }
}

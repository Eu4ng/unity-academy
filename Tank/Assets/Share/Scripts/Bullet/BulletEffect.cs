using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletEffect : MonoBehaviour
{
    [SerializeField] GameObject m_HitEffect;
    IObjectPool<GameObject> m_HitEffectPool;

    private void Start()
    {
        m_HitEffectPool = GameObjectPool.Get(m_HitEffect);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // HitEffect 생성
        GameObject hitEffect = m_HitEffectPool.Get();

        // 스폰 위치 설정
        hitEffect.transform.position = collision.contacts[0].point;
        hitEffect.SetActive(true);
    }
}

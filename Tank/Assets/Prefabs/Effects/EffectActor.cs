using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EffectActor : MonoBehaviour
{
    IObjectPool<GameObject> m_EffectPool;
    ParticleSystem m_ParticleSystem;
    float m_PlayTime;

    private void Awake()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_PlayTime = m_ParticleSystem.time;
    }

    private void OnEnable()
    {
        m_ParticleSystem.Play();
        StartCoroutine("CheckEffectEnd");
    }

    private void OnDisable()
    {
        StopCoroutine("CheckEffectEnd");
    }

    private void Start()
    {
        m_EffectPool = GetComponent<GameObjectPoolTracker>().Pool;
        if (m_EffectPool == null)
            Debug.Log("No EffectPool");
    }

    IEnumerator CheckEffectEnd()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_PlayTime + 0.1f);
            if (!m_ParticleSystem.IsAlive()) m_EffectPool.Release(gameObject);
        }
    }
}

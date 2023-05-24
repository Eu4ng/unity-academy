using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPoolTracker : MonoBehaviour
{
    // 멤버 변수
    IObjectPool<GameObject> m_Pool;

    // 프로퍼티
    public IObjectPool<GameObject> Pool
    {
        get => m_Pool;
        set
        {
            if(m_Pool == null)
                m_Pool = value;
        }
    }
}

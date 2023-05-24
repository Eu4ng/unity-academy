using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPoolTracker : MonoBehaviour
{
    // ��� ����
    IObjectPool<GameObject> m_Pool;

    // ������Ƽ
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

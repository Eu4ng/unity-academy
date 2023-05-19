using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonoSingleton<T> :MonoBehaviour where T : Component
{
    protected static T m_Instance;

    protected virtual void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this.GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public static T Get()
    {
        if (m_Instance == null)
        {
            GameObject emptyGameObject = new GameObject(typeof(T).ToString());
            emptyGameObject.AddComponent<T>();
        }
        
        return m_Instance;
    }
}

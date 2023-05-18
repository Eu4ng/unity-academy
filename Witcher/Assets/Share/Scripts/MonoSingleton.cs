using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonoSingleton<T> :MonoBehaviour where T : MonoBehaviour
{
    protected static GameObject m_Instance;

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public static GameObject Get()
    {
        if (m_Instance == null)
        {
            GameObject emptyGameObject = new GameObject();
            emptyGameObject.AddComponent<T>();
            return MonoSingleton<T>.Get();
        }
        else
            return m_Instance;
    }
}

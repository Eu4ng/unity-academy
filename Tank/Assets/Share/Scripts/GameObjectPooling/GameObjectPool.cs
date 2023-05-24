using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPool : MonoBehaviour
{
    // ��� ����
    IObjectPool<GameObject> m_Pool;
    GameObject m_ParentObject;
    [SerializeField] GameObject m_Prefab;
    [SerializeField] int m_MaxSize = 10;
    [Range(0, 1)]
    [SerializeField] float m_InstanceRatio = 0.5f;
    [SerializeField] bool m_DefferActive = true;

    // �б� ���� ������Ƽ
    public IObjectPool<GameObject> Pool { get => m_Pool; }
    public GameObject Prefab { get => m_Prefab; }


    private void Awake()
    {
        // Object Pool ����
        m_Pool = new ObjectPool<GameObject>(OnCreateObject, OnGetObject, OnReleaseObject, OnDestroyObject, maxSize: m_MaxSize);

        // �ν��Ͻ����� ��Ƶ� Parent ����
        m_ParentObject = new GameObject(m_Prefab.name + " Pool");
        m_ParentObject.transform.parent = gameObject.transform;

        // Object Pool�� �ν��Ͻ����� �̸� ����
        int count = (int)(m_MaxSize * m_InstanceRatio);
        GameObject[] instances = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            instances[i] = m_Pool.Get();
        }

        for (int i = 0; i < count; i++)
        {
            m_Pool.Release(instances[i]);
        }
    }

    // new ObjectPool()
    GameObject OnCreateObject()
    {
        // �������� �ν��Ͻ� ����
        m_Prefab.SetActive(false);
        GameObject instance = Instantiate(m_Prefab);
        m_Prefab.SetActive(true);

        // �ν��Ͻ� �׷�ȭ 
        instance.transform.SetParent(m_ParentObject.transform);

        // �ν��Ͻ��� ���� Pool ���
        instance.AddComponent<GameObjectPoolTracker>().Pool = Pool;
        return instance;
    }

    void OnGetObject(GameObject _instance)
    {
        if(!m_DefferActive) _instance.SetActive(true);
    }

    void OnReleaseObject(GameObject _instance)
    {
        _instance.SetActive(false);
    }

    private void OnDestroyObject(GameObject _instance)
    {
        Destroy(_instance);
    }

    // Static
    // ��� Ȥ�� ��ü ����
    public static IObjectPool<GameObject> Get(GameObject _prefab)
    {
        GameObjectPool[] gameObjectPools = GameObject.FindObjectsOfType<GameObjectPool>();
        foreach (GameObjectPool gameObjectPool in gameObjectPools)
        {
            if (gameObjectPool.Prefab == _prefab)
            {
                return gameObjectPool.Pool;
            }
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRegister : MonoBehaviour
{
    AttributeSet m_AttributeSet;
    [SerializeField] int m_Point = 0;

    private void Awake()
    {
        m_AttributeSet = GetComponent<AttributeSet>();
        if(m_AttributeSet)
            m_AttributeSet.OnDead += () => PointManager.Get().Point += m_Point;
    }
}

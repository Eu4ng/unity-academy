using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    AttributeSet m_AttributeSet;
    Slider m_Slider;
    private void Awake()
    {
        m_AttributeSet = gameObject.GetComponentInParent<AttributeSet>();
        m_Slider = GetComponent<Slider>();
    }

    private void Start()
    {
        m_Slider.value = m_AttributeSet.Hp / m_AttributeSet.MaxHp;
    }

    private void Update()
    {
        m_Slider.value = m_AttributeSet.Hp / m_AttributeSet.MaxHp;
    }
}

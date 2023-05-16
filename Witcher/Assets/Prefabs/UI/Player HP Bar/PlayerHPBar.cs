using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    GameObject m_Player;
    Slider m_Slider;

    private void Awake()
    {
        m_Slider = GetComponent<Slider>();
    }
    private void Start()
    {
        m_Player = GameObject.FindWithTag("Player");

        var attributeSet = m_Player.GetComponent<AttributeSet>();
        if(attributeSet)
        {
            m_Slider.value = attributeSet.Hp / attributeSet.MaxHp;

            attributeSet.OnDamageApplied += () => m_Slider.value = attributeSet.Hp / attributeSet.MaxHp;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

// Hp
public partial class AttributeSet : MonoBehaviour
{
    // �̺�Ʈ
    event Delegate_NoParam OnDead;

    // ����
    [SerializeField]
    bool m_IsDead = false;
    public bool IsDead { get; }
    
    // Attribute
    [SerializeField] int m_Hp;
    public int Hp
    {
        get => m_Hp;
        set
        {
            // ���� ���¿����� �������� ���� ����
            if (IsDead) return;

            // 0 ~ m_MaxHp
            if (value <= 0)
            {
                m_Hp = 0;
                OnDead?.Invoke();
            }
            else if (value >= m_MaxHp)
                m_Hp = m_MaxHp;
            else
                m_Hp = value;
        }
    }
    [SerializeField] int m_MaxHp = 100;

    private void Awake()
    {
        OnDead += () => m_IsDead = true;
    }

    private void OnEnable()
    {
        m_IsDead = false;
        m_Hp = m_MaxHp;
    }
    public void Revive()
    {
        this.enabled = false;
        this.enabled = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSet : MonoBehaviour
{
    public delegate void Func();
    public event Func OnDead;
    public event Func OnDamaged;

    /* Attributes */
    // �ʵ�
    float hp;
    [SerializeField] float maxHp;
    [SerializeField] float damageReduction = 0;
    bool isDead = false;
    public GameObject m_DamageText;

    // ������Ƽ
    public float Hp
    {
        get => hp;
        set
        {
            if (value >= maxHp)
                hp = maxHp;
            else if (value <= 0)
            {
                hp = 0;
                OnDead();
            }
            else
                hp = value;
        }
    } // 0 ~ maxHp
    public float MaxHp
    {
        get => maxHp;
    }
    public float DamageReduction
    {
        get => damageReduction;
        set
        {
            if (value <= 0)
                damageReduction = 0;
            else if (value >= 1)
                damageReduction = 1;
            else
                damageReduction = value;
        }
    } // 0 ~ 1

    private void Awake()
    {
        // �ʱ�ȭ
        Hp = maxHp;

        // Dead �̺�Ʈ ���
        OnDead += () => isDead = true;
    }

    public static void GiveDamage(GameObject target, float damage)
    {
        AttributeSet attributeSet = target.GetComponent<AttributeSet>();
        attributeSet?.Damaged(damage);
    }

    public void Damaged(float damage)
    {
        if (!isDead)
        {
            OnDamaged();
            ShowFloatingDamageText(damage);
        }

        Hp -= damage * (1 - DamageReduction);
    }

    void ShowFloatingDamageText(float _damage)
    {
        // @TODO Instantiate ���� GameObject �ʱ�ȭ�ϴ� ��� �����
        GameObject instance = Instantiate(m_DamageText, gameObject.transform.position, Quaternion.Euler(Vector2.zero));
        instance.GetComponent<FloatingDamageText>().m_Damage = (int)_damage;
        instance.GetComponent<FloatingDamageText>().enabled = true;
    }
}
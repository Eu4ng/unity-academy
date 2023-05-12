using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSet : MonoBehaviour
{
    public delegate void Func();
    public event Func OnDead;
    public event Func OnDamaged;

    /* Attributes */
    // 필드
    float hp;
    public float maxHp;
    public float damageReduction = 0;
    bool isDead = false;

    // 프로퍼티
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
        Hp = maxHp;
        OnDead += () => isDead = true;
    }

    public static void GiveDamage(GameObject target, float damage)
    {
        AttributeSet attributeSet = target.GetComponent<AttributeSet>();
        attributeSet?.Damaged(damage);
    }

    public void Damaged(float damage)
    {
        Hp -= damage * (1 - DamageReduction);

        if (!isDead)
            OnDamaged();
    }
}
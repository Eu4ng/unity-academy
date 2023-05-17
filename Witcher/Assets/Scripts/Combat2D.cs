using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat2D : MonoBehaviour
{
    // �⺻ ������
    public Stats stats;

    // ������Ʈ
    Collider2D actorCollider;

    private void Awake()
    {
        actorCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttributeSet.GiveDamage(collision.gameObject, stats.GetAttackDamage());
    }
}

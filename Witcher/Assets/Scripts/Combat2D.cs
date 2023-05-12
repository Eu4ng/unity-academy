using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat2D : MonoBehaviour
{
    // 기본 설정값
    public Stats stats;

    // 컴포넌트
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

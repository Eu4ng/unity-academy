using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    // �⺻ ������
    public GameObject deathEffect;

    // ������Ʈ
    AttributeSet attributeSet;
    Animator animator;

    private void Awake()
    {
        attributeSet = GetComponent<AttributeSet>();
        attributeSet.OnDead += OnDead;
        attributeSet.OnDamaged += OnHit;

        animator = GetComponent<Animator>();
    }

    private void OnHit()
    {
        int stateID = Animator.StringToHash("Hit");

        if (animator.HasState(0, stateID))
            animator.Play(stateID);
    }

    void OnDead()
    {
        if(deathEffect != null)
            Instantiate(deathEffect, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
        Destroy(gameObject);
    }
}

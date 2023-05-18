using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip m_DeathClip;

    bool m_IsDead = false;

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;
    AudioSource m_AudioSource;
    MovementController m_MovementController;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        m_MovementController = GetComponent<MovementController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !m_IsDead)
            Die();
    }

    void Die()
    {
        // �ִϸ�����
        m_Animator.SetTrigger("IsDead");

        // ����� �ҽ�
        m_AudioSource.clip = m_DeathClip;
        m_AudioSource.Play();

        // ����
        m_Rigidbody.velocity = Vector2.zero;
        m_Rigidbody.gravityScale = 0;
        m_MovementController.enabled = false;

        // ���� �� ����
        m_IsDead = true;

        // ���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.Instance.OnPlayerDead();
    }
}

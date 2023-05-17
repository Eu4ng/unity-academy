using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip m_DeathClip;
    public float m_JumpForce = 700f;

    int m_JumpCount = 0;
    bool m_IsGrounded = false;
    bool m_IsDead = false;

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;
    AudioSource m_AudioSource;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && m_JumpCount < 2)
        {
            // ���� Ƚ�� ����
            m_JumpCount++;

            // ���� ������ �ӵ��� ���������� 0���� ����
            m_Rigidbody.velocity = Vector2.zero;

            // ����
            m_Rigidbody.AddForce(new Vector2(0, m_JumpForce));
            m_AudioSource.Play();
        }
        else if(Input.GetMouseButtonUp(0) && m_Rigidbody.velocity.y > 0)
        {
            m_Rigidbody.velocity *= 0.5f;
        }

        m_Animator.SetBool("IsGrounded", m_IsGrounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !m_IsDead)
            Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹 ǥ���� ������ ���� ������
        if(collision.contacts[0].normal.y > 0.7f)
        {
            m_IsGrounded = true;
            m_JumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_IsGrounded = false;
    }

    void Die()
    {
        // �ִϸ�����
        m_Animator.SetTrigger("IsDead");

        // ����� �ҽ�
        m_AudioSource.clip = m_DeathClip;
        m_AudioSource.Play();

        // �ӵ�
        m_Rigidbody.velocity = Vector2.zero;

        // ���� �� ����
        m_IsDead = true;
    }
}

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
            // 점프 횟수 증가
            m_JumpCount++;

            // 점프 직전에 속도를 순간적으로 0으로 변경
            m_Rigidbody.velocity = Vector2.zero;

            // 점프
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
        // 충돌 표면이 위쪽을 보고 있으면
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
        // 애니메이터
        m_Animator.SetTrigger("IsDead");

        // 오디오 소스
        m_AudioSource.clip = m_DeathClip;
        m_AudioSource.Play();

        // 속도
        m_Rigidbody.velocity = Vector2.zero;

        // 변수 값 설정
        m_IsDead = true;
    }
}

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
        // 애니메이터
        m_Animator.SetTrigger("IsDead");

        // 오디오 소스
        m_AudioSource.clip = m_DeathClip;
        m_AudioSource.Play();

        // 정지
        m_Rigidbody.velocity = Vector2.zero;
        m_Rigidbody.gravityScale = 0;
        m_MovementController.enabled = false;

        // 변수 값 설정
        m_IsDead = true;

        // 게임 매니저의 게임오버 처리 실행
        GameManager.Instance.OnPlayerDead();
    }
}

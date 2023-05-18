using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    [System.Serializable]
    public class Move2D
    {
        public enum View
        {
            Side,
            Top
        }

        // 움직임 설정
        [Header("Move Parameters")]
        public bool m_LockMove = false;
        public float m_Speed = 5f;
        public View m_View = View.Side;

        // 점프 설정
        [Header("Jump Parameters")]
        public int m_MaxJumpCount = 1;
        public float m_JumpForce = 10f;
        public AudioClip m_JumpSound;

        int m_JumpCount = 0;
        bool m_IsGrounded = true;
        public bool IsGrounded
        {
            get => m_IsGrounded;
            set
            {
                // Land 후 점프 횟수 초기화
                if (!m_IsGrounded && value)
                    m_JumpCount = 0;

                m_IsGrounded = value;

                // 애니메이터 변수 동기화
                if(m_Animator != null)
                {
                    m_Animator.SetBool(m_AnimIsGrounded, value);
                    if(!m_IsGrounded && !value) // 공중에 뜬 상태에서 점프 시
                        m_Animator.SetTrigger(m_AnimJumpAgain);
                }
            }
        }

        // 애니메이터 변수 설정
        [Header("Animator Parameters")]
        public string m_AnimIsGrounded = "IsGrounded";
        public string m_AnimJumpAgain = "JumpAgain";

        // 움직일 대상
        GameObject m_Target;
        public GameObject Target
        {
            get => m_Target;
            set
            {
                if (m_Target != null)
                    return;

                m_Target = value;
                Init();
            }
        }

        // 대상 컴포넌트
        Rigidbody2D m_Rigidbody;
        Animator m_Animator;
        AudioSource m_AudioSource;

        // 초기화
        public void Init()
        {
            // 컴포넌트 할당
            m_Rigidbody = m_Target.GetComponent<Rigidbody2D>();
            m_Animator = m_Target.GetComponent <Animator>();
            m_AudioSource = m_Target.GetComponent<AudioSource>();
        } // set Target시 실행됨

        // Move
        public void Move(Vector2 _inputValue, float _deltaTime)
        {
            // Lock Move 확인
            if (m_LockMove)
                return;

            // 대각 이동시 속도가 증가하는 것 방지
            Vector2 inputValue = _inputValue.normalized;

            // x축, y축 이동
            if (inputValue.x != 0)
                MoveRight(_inputValue.x, _deltaTime);
            if (inputValue.y != 0)
                MoveForward(_inputValue.y, _deltaTime);
        }
        public void MoveForward(float _inputValue, float _deltaTime)
        {
            TranslateForward(_inputValue, _deltaTime);
        }
        public void MoveRight(float _inputValue, float _deltaTime)
        {
            TranslateRight(_inputValue, _deltaTime);
        }

        // Translate
        void TranslateForward(float _inputValue, float _deltaTime)
        {
            switch (m_View)
            {
                case View.Top:
                    TranslateUp(_inputValue, _deltaTime);
                    break;
            }
        } // Top View 방식에서만 동작
        void TranslateUp(float _inputValue, float _deltaTime)
        {
            TranslateTo(_inputValue, _deltaTime, Vector2.up);
        }
        void TranslateRight(float _inputValue, float _deltaTime)
        {
            TranslateTo(_inputValue, _deltaTime, Vector2.right);
        }
        void TranslateTo(float _inputValue, float _deltaTime, Vector2 _direction)
        {
            m_Target.transform.Translate(m_Speed * _deltaTime * _inputValue * _direction);
        }

        // Jump
        // Side View 방식에서만 동작
        // Rigidbody2D 컴포넌트 필요
        public void Jump()
        {
            // Rigidbody 부착 여부 확인
            if (m_Rigidbody == null)
                return;

            // Impulse
            switch(m_View)
            {
                case View.Side:
                    if(m_JumpCount < m_MaxJumpCount)
                    {
                        // 변수 설정
                        m_JumpCount++;

                        // 점프 전에 y축 속도값을 0으로 설정
                        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0);

                        // 점프 사운드 재생
                        m_AudioSource.clip = m_JumpSound;
                        m_AudioSource.Play();

                        // 점프
                        m_Rigidbody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
                    }
                    break;
            }
        }

    }
}

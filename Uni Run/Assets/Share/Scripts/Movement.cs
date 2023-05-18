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

        // ������ ����
        [Header("Move Parameters")]
        public bool m_LockMove = false;
        public float m_Speed = 5f;
        public View m_View = View.Side;

        // ���� ����
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
                // Land �� ���� Ƚ�� �ʱ�ȭ
                if (!m_IsGrounded && value)
                    m_JumpCount = 0;

                m_IsGrounded = value;

                // �ִϸ����� ���� ����ȭ
                if(m_Animator != null)
                {
                    m_Animator.SetBool(m_AnimIsGrounded, value);
                    if(!m_IsGrounded && !value) // ���߿� �� ���¿��� ���� ��
                        m_Animator.SetTrigger(m_AnimJumpAgain);
                }
            }
        }

        // �ִϸ����� ���� ����
        [Header("Animator Parameters")]
        public string m_AnimIsGrounded = "IsGrounded";
        public string m_AnimJumpAgain = "JumpAgain";

        // ������ ���
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

        // ��� ������Ʈ
        Rigidbody2D m_Rigidbody;
        Animator m_Animator;
        AudioSource m_AudioSource;

        // �ʱ�ȭ
        public void Init()
        {
            // ������Ʈ �Ҵ�
            m_Rigidbody = m_Target.GetComponent<Rigidbody2D>();
            m_Animator = m_Target.GetComponent <Animator>();
            m_AudioSource = m_Target.GetComponent<AudioSource>();
        } // set Target�� �����

        // Move
        public void Move(Vector2 _inputValue, float _deltaTime)
        {
            // Lock Move Ȯ��
            if (m_LockMove)
                return;

            // �밢 �̵��� �ӵ��� �����ϴ� �� ����
            Vector2 inputValue = _inputValue.normalized;

            // x��, y�� �̵�
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
        } // Top View ��Ŀ����� ����
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
        // Side View ��Ŀ����� ����
        // Rigidbody2D ������Ʈ �ʿ�
        public void Jump()
        {
            // Rigidbody ���� ���� Ȯ��
            if (m_Rigidbody == null)
                return;

            // Impulse
            switch(m_View)
            {
                case View.Side:
                    if(m_JumpCount < m_MaxJumpCount)
                    {
                        // ���� ����
                        m_JumpCount++;

                        // ���� ���� y�� �ӵ����� 0���� ����
                        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0);

                        // ���� ���� ���
                        m_AudioSource.clip = m_JumpSound;
                        m_AudioSource.Play();

                        // ����
                        m_Rigidbody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
                    }
                    break;
            }
        }

    }
}

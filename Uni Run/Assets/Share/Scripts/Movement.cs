using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    [System.Serializable]
    public class Move2D
    {
        public enum Method
        {
            Transform,
            RigidbodyTransform,
            Velocity
        }
        public enum View
        {
            Side,
            Top
        }
        public enum UpdateType
        {
            Update,
            FixedUpdate
        }

        // ������ ����
        public bool m_CanMove = true;
        public float m_Speed;
        public Method m_Method = Method.Transform;
        public View m_View = View.Side;
        public UpdateType m_UpdateType = UpdateType.Update;

        // Method.Velocity
        

        // ������ ���� ������Ʈ
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

        // ������Ʈ
        Rigidbody2D m_Rigidbody;

        // PlayerController���� ����� �޼ҵ�
        public void Init()
        {
            m_Rigidbody = m_Target.GetComponent<Rigidbody2D>();
        } // set Target�� �����
        public void Move(Vector2 _inputValue)
        {
            // �밢 �̵��� �ӵ��� �����ϴ� �� ����
            Vector2 inputValue = _inputValue.normalized;

            // For SetVelocity
            if (m_Method.Equals(Method.Velocity))
                m_Rigidbody.velocity = Vector2.zero;

            // x��, y�� �̵�
            if (inputValue.x != 0)
                MoveRight(_inputValue.x);
            if (inputValue.y != 0)
                MoveForward(_inputValue.y);
        }
        public void MoveForward(float _inputValue)
        {
            // Check Can Move
            if (!m_CanMove)
                return;

            // Apply Move
            switch(m_Method)
            {
                case Method.Transform:
                    TranslateForward(_inputValue);
                    break;
                case Method.RigidbodyTransform:
                    // TODO
                    break;
                case Method.Velocity:
                    SetForwardVeloctiy(_inputValue);
                    break;
            }
        }
        public void MoveRight(float _inputValue)
        {
            // Check Can Move
            if (!m_CanMove)
                return;

            // Apply Move
            switch (m_Method)
            {
                case Method.Transform:
                    TranslateRight(_inputValue);
                    break;
                case Method.RigidbodyTransform:
                    // TODO
                    break;
                case Method.Velocity:
                    SetRightVeloctiy(_inputValue);
                    break;
            }
        }

        // Method.Transform
        void TranslateForward(float _inputValue)
        {
            switch(m_View)
            {
                case View.Top:
                    TranslateUp(_inputValue);
                    break;
            }
        } // Top View ��Ŀ����� ����
        void TranslateUp(float _inputValue)
        {
            TranslateTo(_inputValue, Vector2.up);
        }
        void TranslateRight(float _inputValue)
        {
            TranslateTo(_inputValue, Vector2.right);
        }
        void TranslateTo(float _inputValue, Vector2 _direction)
        {
            switch(m_UpdateType)
            {
                case UpdateType.Update:
                    m_Target.transform.Translate(m_Speed * Time.deltaTime * _inputValue * _direction);
                    break;
                case UpdateType.FixedUpdate:
                    m_Target.transform.Translate(m_Speed * Time.fixedDeltaTime * _inputValue * _direction);
                    break;
            }
        }

        // Method.RigidbodyTransform

        // Method.RigidbodyVelocity
        void SetForwardVeloctiy(float _inputValue)
        {
            switch (m_View)
            {
                case View.Top:
                    SetUpVeloctiy(_inputValue);
                    break;
            }
        }
        void SetUpVeloctiy(float _inputValue)
        {
            SetVeloctiy(_inputValue, Vector2.up);
        }
        void SetRightVeloctiy(float _inputValue)
        {
            SetVeloctiy(_inputValue, Vector2.right);
        }
        void SetVeloctiy(float _inputValue, Vector2 _direction)
        {
            m_Rigidbody.velocity += m_Speed * _inputValue * _direction;
        } // Rigidbody.velocity = Vector2.zero ����Ǿ�� ��
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class InputController : MonoBehaviour
{
    // Input 설정
    [SerializeField] protected string m_HorizontalAxis = "Horizontal";
    [SerializeField] protected string m_VerticalAxis = "Vertical";

    protected float m_InputX;
    protected float m_InputY;

    // Movement 설정 (Move, Jump)
    [SerializeField] protected Movement.Move2D m_Movement = new Movement.Move2D();

    protected virtual void Awake()
    {
        m_Movement.Target = gameObject;
    }

    protected virtual void Update()
    {
        // Move를 위한 사용자 입력 확인
        m_InputX = Input.GetAxis(m_HorizontalAxis);
        m_InputY = Input.GetAxis(m_VerticalAxis);

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 점프
            m_Movement.Jump();
        }
    }

    protected virtual void FixedUpdate()
    {
        m_Movement.Move(new Vector2(m_InputX, m_InputY), Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y >= 0.7f)
            m_Movement.IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_Movement.IsGrounded = false;
    }
}

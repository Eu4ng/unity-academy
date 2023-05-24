using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ProjectileMovement : MonoBehaviour
{
    // 컴포넌트
    Rigidbody m_Rigidbody;

    // Movement
    public float m_Speed = 3f;

    // 발사대
    public GameObject m_Shooter;

    // 코루틴
    Coroutine m_cr_AlignRotation;

    private void Awake()
    {
        // 컴포넌트 할당
        m_Rigidbody = GetComponent<Rigidbody>();
        
        // Collision Detection 모드 변경
        // 보통 빠르고 작은 콜라이더를 사용하기 때문
        if(m_Rigidbody.collisionDetectionMode == CollisionDetectionMode.Discrete)
            m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void OnEnable()
    {
        // 발사체 초기 속도 설정
        m_Rigidbody.velocity = transform.forward * m_Speed;

        // 발사대의 속도를 추가
        Rigidbody shooterRigidbody = m_Shooter.GetComponent<Rigidbody>();
        if(shooterRigidbody != null)
            m_Rigidbody.velocity += shooterRigidbody.velocity;

        // 코루틴 시작
        m_cr_AlignRotation = StartCoroutine(AlignRotation());
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopCoroutine(m_cr_AlignRotation);
    }

    IEnumerator AlignRotation()
    {
        while(true)
        {
            yield return new WaitForFixedUpdate();
            transform.rotation = Quaternion.LookRotation(m_Rigidbody.velocity);
        }
    }
}

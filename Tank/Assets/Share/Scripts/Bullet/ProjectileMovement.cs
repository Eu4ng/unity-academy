using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ProjectileMovement : MonoBehaviour
{
    // ������Ʈ
    Rigidbody m_Rigidbody;

    // Movement
    public float m_Speed = 3f;

    // �߻��
    public GameObject m_Shooter;

    // �ڷ�ƾ
    Coroutine m_cr_AlignRotation;

    private void Awake()
    {
        // ������Ʈ �Ҵ�
        m_Rigidbody = GetComponent<Rigidbody>();
        
        // Collision Detection ��� ����
        // ���� ������ ���� �ݶ��̴��� ����ϱ� ����
        if(m_Rigidbody.collisionDetectionMode == CollisionDetectionMode.Discrete)
            m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void OnEnable()
    {
        // �߻�ü �ʱ� �ӵ� ����
        m_Rigidbody.velocity = transform.forward * m_Speed;

        // �߻���� �ӵ��� �߰�
        Rigidbody shooterRigidbody = m_Shooter.GetComponent<Rigidbody>();
        if(shooterRigidbody != null)
            m_Rigidbody.velocity += shooterRigidbody.velocity;

        // �ڷ�ƾ ����
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

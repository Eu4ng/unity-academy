using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // �⺻ ������
    public float speed = 8f;
    public Vector2 direction;

    // ������Ʈ
    Rigidbody2D actorRigidbody;

    void Awake()
    {
        // ������Ʈ �Ҵ�
        actorRigidbody = GetComponent<Rigidbody2D>();

        // ������Ʈ �ʱ�ȭ
        if(direction != Vector2.zero)
            actorRigidbody.velocity = direction * speed;
    }
}

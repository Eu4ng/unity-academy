using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // 기본 설정값
    public float speed = 8f;
    public Vector2 direction;

    // 컴포넌트
    Rigidbody2D actorRigidbody;

    void Awake()
    {
        // 컴포넌트 할당
        actorRigidbody = GetComponent<Rigidbody2D>();

        // 컴포넌트 초기화
        if(direction != Vector2.zero)
            actorRigidbody.velocity = direction * speed;
    }
}

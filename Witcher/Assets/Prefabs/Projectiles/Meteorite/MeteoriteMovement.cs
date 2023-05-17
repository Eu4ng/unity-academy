using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : MonoBehaviour
{
    // �⺻ ������
    public float speed = 8f;

    // ������Ʈ
    Rigidbody2D actorRigidbody;

    void Awake()
    {
        // ������Ʈ �Ҵ�
        actorRigidbody = GetComponent<Rigidbody2D>();

        // ������Ʈ �ʱ�ȭ
        actorRigidbody.velocity = Vector2.down * speed;
    }
}

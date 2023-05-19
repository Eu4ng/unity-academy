using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �⺻ ������
    public float speed = 5f;
    public float movableWidth = 5f;

    // ����� �Է�
    float inputValue;

    // ������Ʈ
    Rigidbody2D playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
        LimitMove();
    }

    void GetPlayerInput()
    {
        inputValue = Input.GetAxis("Horizontal");
    }
    void Move()
    {
        playerRigidbody.velocity = Vector2.right * speed * inputValue;
    }
    void LimitMove()
    {
        playerRigidbody.transform.position = new Vector2(Mathf.Clamp(playerRigidbody.transform.position.x, -movableWidth, movableWidth), playerRigidbody.transform.position.y);
    }
}

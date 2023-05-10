using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float speed = 8f;
    public bool test = false;

    Vector2 inputValue;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputValue.x = Input.GetAxis("Vertical");
        inputValue.y = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 velocity = (Vector3.forward * inputValue.x + Vector3.right * inputValue.y).normalized * speed;

        rigidbody.velocity = velocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}

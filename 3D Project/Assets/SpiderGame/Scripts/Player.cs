using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float rotSpeed = 200f;

    [SerializeField] bool bInputEnable = true;
    public bool bMoveWithAxis = true;


    Animation anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animation>();

        PointManager.Get().OnGameOver.AddListener(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if(bInputEnable)
        {
            if (bMoveWithAxis)
            {
                MoveWithAxis();
            }
            else
            {
                MoveWithKey();
            }
        }
    }

    void MoveWithKey()
    {
        if(Input.GetKey(KeyCode.W))
        {
            // print("Key");
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            anim.CrossFade("walk");
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            anim.CrossFade("walk");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotSpeed * Time.deltaTime);
            anim.CrossFade("walk");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            anim.CrossFade("walk");
        }
        else
        {
            anim.CrossFade("idle");
        }
    }

    void MoveWithAxis()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (movementInput != Vector2.zero)
        {
            // print("Axis");
            // Move2D(movementInput);
            MoveForward(movementInput.x);
            RotateRight(movementInput.y);

            anim.CrossFade("walk");
        }
        else
        {
            anim.CrossFade("idle");
        }
    }

    void MoveForward(float inputValue)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * inputValue);
    }
    void Move2D(Vector2 inputValue)
    {
        Vector2 movement = inputValue * speed * Time.deltaTime;

        Vector3 forwardMovement = Vector3.forward * movement.x;
        Vector3 rightdMovement = Vector3.right * movement.y;

        transform.Translate(forwardMovement + rightdMovement);
    }

    void RotateRight(float inputValue)
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * inputValue);
    }

    void GameOver()
    {
        bInputEnable = false;

        if(anim)
        {
            anim.CrossFade("idle");
        }
    }
}

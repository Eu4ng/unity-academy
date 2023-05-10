using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotator : MonoBehaviour
{
    [SerializeField] float rotSpeed = 8f;

    void Update()
    {
        transform.Rotate(0f, rotSpeed * Time.deltaTime, 0f);
    }
}

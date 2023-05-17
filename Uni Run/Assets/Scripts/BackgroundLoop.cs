using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float width;

    void Awake()
    {
        width = GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x <= -width)
            Reposition();
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}

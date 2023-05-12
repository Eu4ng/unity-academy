using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShooter : MonoBehaviour
{
    public GameObject missile;
    public Vector2 spawnOffset;
    public float fireRate = 0.5f;
    float coolTime = 0;

    private void Update()
    {
        coolTime += Time.deltaTime;
        if (coolTime >= fireRate)
        {
            Fire();
            coolTime = 0;
        }
    }

    void Fire()
    {
        Instantiate(missile, (Vector2)transform.position + spawnOffset, Quaternion.Euler(Vector2.zero));
    }
}

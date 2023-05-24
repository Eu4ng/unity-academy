using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class FireArm : MonoBehaviour
{
    IObjectPool<GameObject> m_BulletPool;
    [SerializeField] GameObject m_BulletPrefab;
    [SerializeField] Transform m_Muzzle;

    private void Start()
    {
        m_BulletPool = GameObjectPool.Get(m_BulletPrefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Fire();
    }

    private void Fire()
    {
        // Bullet 생성
        GameObject bullet;
        if (m_BulletPool != null)
            bullet = m_BulletPool.Get();
        else
        {
            m_BulletPrefab.SetActive(false);
            bullet = Instantiate(m_BulletPrefab);
            m_BulletPrefab.SetActive(true);
        }


        // Spawn Transform 설정
        bullet.transform.position = m_Muzzle.position;
        bullet.transform.rotation = m_Muzzle.rotation;

        // ProjectileMovement 설정
        ProjectileMovement projectileMovement = bullet.GetComponent<ProjectileMovement>();
        //projectileMovement.m_Speed = 10f;
        projectileMovement.m_Shooter = gameObject;
        bullet.SetActive(true);
    }
}

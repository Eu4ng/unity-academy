using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float spawnMinRate = 0.5f;
    [SerializeField] float spawnMaxRate = 3f;

    Transform target;
    float spawnRate;
    float timeAfterSpawn = 0;

    // Start is called before the first frame update
    void Awake()
    {
        spawnRate = Random.Range(spawnMinRate, spawnMaxRate);
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate && target.gameObject.activeSelf)
        {
            GameObject spawnedBullet = Instantiate(bulletPrefab, transform);
            spawnedBullet.transform.LookAt(target);
            timeAfterSpawn = 0;
        }
    }
}

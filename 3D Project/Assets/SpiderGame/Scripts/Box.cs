using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Box : MonoBehaviour
{
    Collider boxCollider;

    [SerializeField]
    AudioClip audioClip;

    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<Collider>();

        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) { return; }

        // 포인트 적립
        PointManager.Get().AddPoints(1);

        // 효과음 재생
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        }

        Destroy(gameObject);
    }
}

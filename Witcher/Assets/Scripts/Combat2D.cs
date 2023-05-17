using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat2D : MonoBehaviour
{
    // �⺻ ������
    public Stats stats;
    public List<string> enemyTagNames;
    public List<string> friendTagNames;
    public GameObject hitEffect;

    // ������Ʈ
    Collider2D actorCollider;

    private void Awake()
    {
        actorCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Friend Tag List�� ��ϵ� GameObject���� ����
        if (CheckFriend(collision))
            return;

        // Enemy Tag List�� ��ϵ� GameObject�鿡�� �������� ����
        // Enemy Tag List�� ����ִٸ� Friend�� ������ ��� GameObject�鿡 ������ ����
        if (enemyTagNames.Count <= 0 || CheckEnemy(collision))
        {
            SpawnHitEffect();
            AttributeSet.GiveDamage(collision.gameObject, stats.GetAttackDamage());
            Destroy(gameObject);
        }
    }

    void SpawnHitEffect()
    {
        if (hitEffect)
            Instantiate(hitEffect, transform.position, Quaternion.Euler(Vector2.zero));
    }

    bool CheckFriend(Collider2D collision)
    {
        return CheckTagList(collision, friendTagNames);
    }

    bool CheckEnemy(Collider2D collision)
    {
        return CheckTagList(collision, enemyTagNames);
    }

    bool CheckTagList(Collider2D collision, List<string> tagList)
    {
        foreach (string tag in tagList)
        {
            if (collision.gameObject.CompareTag(tag))
                return true;
        }

        return false;
    }
}

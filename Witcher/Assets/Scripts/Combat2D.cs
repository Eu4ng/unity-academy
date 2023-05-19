using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat2D : MonoBehaviour
{
    // �⺻ ������
    public Stats m_Stats;
    public List<string> m_EnemyTagNames;
    public List<string> m_FriendTagNames;
    public GameObject m_HitEffect;
    public bool m_DestroyAfterHit = false;

    // ������Ʈ
    Collider2D m_Collider;

    private void Awake()
    {
        m_Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Friend Tag List�� ��ϵ� GameObject���� ����
        if (CheckFriend(collision))
            return;

        // Enemy Tag List�� ��ϵ� GameObject�鿡�� �������� ����
        // Enemy Tag List�� ����ִٸ� Friend�� ������ ��� GameObject�鿡 ������ ����
        if (m_EnemyTagNames.Count <= 0 || CheckEnemy(collision))
        {
            SpawnHitEffect();
            AttributeSet.GiveDamage(collision.gameObject, m_Stats.GetAttackDamage());
            if(m_DestroyAfterHit)
                Destroy(gameObject);
        }
    }

    void SpawnHitEffect()
    {
        if (m_HitEffect)
            Instantiate(m_HitEffect, transform.position, Quaternion.Euler(Vector2.zero));
    }

    bool CheckFriend(Collider2D collision)
    {
        return CheckTagList(collision, m_FriendTagNames);
    }

    bool CheckEnemy(Collider2D collision)
    {
        return CheckTagList(collision, m_EnemyTagNames);
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

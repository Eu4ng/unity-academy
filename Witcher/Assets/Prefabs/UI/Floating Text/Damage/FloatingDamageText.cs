using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingDamageText : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 1f;
    [SerializeField] float m_AlphaSpeed = 2f;
    [SerializeField] float m_DestoryTime = 2f;
    TextMeshPro m_Text;
    Color m_Alpha;

    public int m_Damage;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        m_Alpha = m_Text.color;
        m_Text.text = m_Damage.ToString();
        Invoke("SelfDestroy", m_DestoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, m_MoveSpeed * Time.deltaTime, 0)); // 텍스트 위치

        m_Alpha.a = Mathf.Lerp(m_Alpha.a, 0, Time.deltaTime * m_AlphaSpeed); // 텍스트 알파값
        m_Text.color = m_Alpha;
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}

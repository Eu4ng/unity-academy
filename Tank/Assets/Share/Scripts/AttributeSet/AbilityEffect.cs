using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AttributeSet;

public class AbilityEffect : MonoBehaviour
{
    enum ATTRIBUTE
    {
        Hp,
        Mp
    }

    static readonly Dictionary<ATTRIBUTE, string> AttributeTable = new Dictionary<ATTRIBUTE, string>
    { 
        {ATTRIBUTE.Hp, "Hp"},
        {ATTRIBUTE.Mp, "Mp"}
    };

    [SerializeField] ATTRIBUTE m_PropertyName = ATTRIBUTE.Hp;
    [SerializeField] AttributeSet.MODIFIER_OP m_Modifier_Op = AttributeSet.MODIFIER_OP.Add;
    [SerializeField] float m_Value = 0f;

    public bool ApplyEffect(GameObject _target)
    {
        return AttributeSet.ModifyProperty(_target, AttributeTable[m_PropertyName], m_Modifier_Op, m_Value);
    }
}

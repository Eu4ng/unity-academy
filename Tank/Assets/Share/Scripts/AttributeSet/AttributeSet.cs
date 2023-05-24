using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AttributeSet : MonoBehaviour
{
    public delegate void Delegate_NoParam();

    public enum MODIFIER_OP
    {
        Add,
        Multiply,
        Divide,
        Override
    }

    public static bool ModifyProperty(GameObject _target, string _propertyName, MODIFIER_OP _operator, float _value)
    {
        // Attribute Set 확인
        AttributeSet attributeSet = _target.GetComponent<AttributeSet>();
        if (attributeSet == null) return false;

        // 프로퍼티 확인
        System.Reflection.PropertyInfo prop = attributeSet.GetType().GetProperty(_propertyName);
        if (prop == null) return false;

        // MODIFIER_OP에 따라 계산
        int propValue = (int)prop.GetValue(attributeSet);
        switch (_operator)
        {
            case MODIFIER_OP.Add:
                propValue = (int)(propValue + _value);
                break;
            case MODIFIER_OP.Multiply:
                propValue = (int)(propValue * _value);
                break;
            case MODIFIER_OP.Divide:
                propValue = (int)(propValue / _value);
                break; 
            case MODIFIER_OP.Override:
                propValue = (int)_value;
                break;
        }

        // 프로퍼티 값 수정
        prop.SetValue(attributeSet, propValue);
        return true;
    }
}
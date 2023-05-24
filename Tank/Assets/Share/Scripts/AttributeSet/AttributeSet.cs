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
        // Attribute Set Ȯ��
        AttributeSet attributeSet = _target.GetComponent<AttributeSet>();
        if (attributeSet == null) return false;

        // ������Ƽ Ȯ��
        System.Reflection.PropertyInfo prop = attributeSet.GetType().GetProperty(_propertyName);
        if (prop == null) return false;

        // MODIFIER_OP�� ���� ���
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

        // ������Ƽ �� ����
        prop.SetValue(attributeSet, propValue);
        return true;
    }
}
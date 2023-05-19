using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Stats
{
    public float baseDamage;
    public float multiplier;

    public float GetAttackDamage()
    {
        return baseDamage * multiplier;
    }
}

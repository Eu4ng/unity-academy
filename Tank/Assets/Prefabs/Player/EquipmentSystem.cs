using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    public Transform m_WeaponSocket;
    public GameObject m_Weapon;

    private void Awake()
    {
        Instantiate(m_Weapon, m_WeaponSocket);
    }
}

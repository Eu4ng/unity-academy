using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceUI : MonoBehaviour
{
    TextMeshProUGUI m_Text;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_Text.text = PointManager.Get().Distance.ToString("N0") + " M";
    }
}

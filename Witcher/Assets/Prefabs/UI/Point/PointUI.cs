using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointUI : MonoBehaviour
{
    TextMeshProUGUI m_Text;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_Text.text = PointManager.Get().Point.ToString("N0");
    }
}

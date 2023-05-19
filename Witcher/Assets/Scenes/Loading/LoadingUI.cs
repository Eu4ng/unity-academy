using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingUI : MonoBehaviour
{
    public TextMeshProUGUI m_LoadingText;
    public TextMeshProUGUI m_LoadingPercentage;
    public Slider m_Slider; // 1개만 존재해야한다

    private void Update()
    {
        m_LoadingPercentage.text = (int)(m_Slider.value * 100) + " %";
        if (Mathf.Approximately(m_Slider.value, 1f))
        {
            m_LoadingPercentage.text = "100 %";
            m_LoadingText.text = "Loading Complete";
        }
    }
}

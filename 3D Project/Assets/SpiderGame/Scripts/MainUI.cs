using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private Image titleLogo;

    private void Awake()
    {
        // 포인트
        PointManager.Get().OnPointChanged.AddListener(UpdatePoint);
        PointManager.Get().OnGameOver.AddListener(() => DisplayTitleLogo(true));

        UpdatePoint();

        // 게임 오버 로고
        DisplayTitleLogo(false);
    }

    void UpdatePoint()
    {
        if(pointText == null) { return; }

        pointText.text = PointManager.Get().point.ToString();
    }

    void DisplayTitleLogo(bool bEnable)
    {
        if (titleLogo)
        {
            titleLogo.gameObject.SetActive(bEnable);
        }
    }
}

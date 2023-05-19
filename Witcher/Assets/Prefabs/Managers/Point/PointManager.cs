using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : GenericSingleton<PointManager>
{
    delegate void Func();
    event Func OnGameOver;

    bool m_IsGameOver = false;
    public bool IsGameOver
    {
        get => m_IsGameOver;
        set
        {
            IsGameOver = value;
            if (IsGameOver)
                OnGameOver();
        }
    }

    float m_Distance = 0;
    [SerializeField] float m_MaxDistance = 0;
    public float Distance
    {
        get => m_Distance;
        set
        {
            if (value <= 0)
                m_Distance = 0;
            else
                m_Distance = value;

            // Check GameOver
            if (Mathf.Approximately(m_MaxDistance, 0))
                return;

            if (m_Distance >= m_MaxDistance)
                OnGameOver();
        }
    }

    int m_Point = 0;
    [SerializeField] int m_MaxPoint = 0;
    public int Point
    {
        get => m_Point;
        set
        {
            if (value <= 0)
                m_Point = 0;
            else
                m_Point = value;

            // Check GameOver
            if (m_MaxPoint == 0)
                return;

            if (m_MaxPoint >= m_Point)
                OnGameOver();
        }
    }
}

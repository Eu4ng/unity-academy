using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    void Awake()
    {
        PointManager.Get().OnPointChanged.AddListener(PrintPoint);

        PrintPoint();
    }

    void PrintPoint()
    {
        print(PointManager.Get().point);
    }
}

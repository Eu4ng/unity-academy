using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointManager : GenericSingleton<PointManager>
{
    public int point { get; private set; } = 0;

    public UnityEvent OnPointChanged = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();

    public void AddPoints(int points)
    {
        point += points;

        OnPointChanged?.Invoke();

        if(point >= 5)
        {
            OnGameOver?.Invoke();
        }
    }

}

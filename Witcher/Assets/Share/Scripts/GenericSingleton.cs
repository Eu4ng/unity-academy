using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> where T : new()
{
    protected static T instance;

    public static T Get()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }
}

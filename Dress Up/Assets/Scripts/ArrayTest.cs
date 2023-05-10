using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    int[] myGameScore;
    // Start is called before the first frame update
    void Start()
    {
        myGameScore = new int[] { 100, 90, 78, 88, 75 };

        foreach(int i in myGameScore)
        {
            print(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

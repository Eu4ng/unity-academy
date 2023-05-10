using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void GoToDressRoom()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public static void GoToCustomizing()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

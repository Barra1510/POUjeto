using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScreenTransition : MonoBehaviour
{
    [SerializeField] GameObject[] screenList;
    private int actualScreen = 0;
    public void GoTo(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void GoLeft()
    {
        screenList[actualScreen].SetActive(false);
        if (actualScreen != 0)
        {
            actualScreen -= 1;
            screenList[actualScreen].SetActive(true);
        }
        if(actualScreen == 0)
        {
            screenList[actualScreen].SetActive(true); ;
        }
    }

    public void GoRight()
    {
        screenList[actualScreen].SetActive(false);
        if (actualScreen != 2)
        {
            actualScreen += 1;
            screenList[actualScreen].SetActive(true);
        }
        if (actualScreen == screenList.Length - 1)
        {
            screenList[actualScreen].SetActive(true); ;
        }
    }
}

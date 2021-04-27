using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScreenTransition : MonoBehaviour
{
    private GameObject[] screenList;
    [SerializeField] int actualScreen = 0;
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToAR()
    {
        SceneManager.LoadScene("Teste Vuforia");
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

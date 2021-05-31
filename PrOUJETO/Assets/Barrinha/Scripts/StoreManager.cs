using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    [SerializeField] GameObject[] imageList;
    [SerializeField] GameObject storePanel;
    [SerializeField] Image[] image;
    [SerializeField] Text[] quantItem;

    private int actualImage = 0;
    private int[] quant = new int[5];

    public void PanelOn()
    {
        if (!storePanel.activeInHierarchy)        
            storePanel.SetActive(true);
        else
            storePanel.SetActive(false);  
    }
    public void Plus1()
    {
        quant[0] += 1;
        quantItem[0].text = "x" + quant[0].ToString();
        
    }
    public void Plus2()
    {
        quant[1] += 1;
        quantItem[1].text = "x" + quant[1].ToString();
    }
    public void Plus3()
    {
        quant[2] += 1;
        quantItem[2].text = "x" + quant[2].ToString();
    }
    public void Plus4()
    {
        quant[3] += 1;
        quantItem[3].text = "x" + quant[3].ToString();
    }
    public void Plus5()
    {
        quant[4] += 1;
        quantItem[4].text = "x" + quant[4].ToString();
    }
    public void Plus6()
    {
        quant[5] += 1;
        quantItem[5].text = "x" + quant[5].ToString();
    }

    public void GoLeftItem()
    {
        imageList[actualImage].SetActive(false);
        if (actualImage != 0)
        {
            actualImage -= 1;
            imageList[actualImage].SetActive(true);
        }
        if (actualImage == 0)
        {
            imageList[actualImage].SetActive(true); ;
        }
    }

    public void GoRightItem()
    {
        imageList[actualImage].SetActive(false);
        if (actualImage != 5)
        {
            actualImage += 1;
            imageList[actualImage].SetActive(true);
        }
        if (actualImage == imageList.Length - 1)
        {
            imageList[actualImage].SetActive(true); ;
        }
    }
}

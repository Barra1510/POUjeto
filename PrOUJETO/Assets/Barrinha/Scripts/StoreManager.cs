using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    [Header("Painel da Loja")]
    [SerializeField] GameObject storePanel;
    [Header("Lista de imagens da loja")]
    [SerializeField] GameObject[] imageList;
    [Header("Lista de imagens do inventário do player")]
    [SerializeField] Image[] image;
    [Header("Textos de multiplicação")]
    [SerializeField] Text[] quantItem;
    [Header("Referência ao Status")]
    [SerializeField] StatusManager status;

    [Header("Valor de item")]
    [SerializeField] int[] valorItem;
    [Header("Dinheiro")]
    [SerializeField] int money;
    [SerializeField] Text moneyText;    

    [SerializeField] PlayerMove player;     
    private int actualImage = 0;
    private int[] quant = new int[5];

    private XML xml;
    
    [SerializeField] GameObject panelPause;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void StartAgain()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        for (int i = 0; i <= 5; i++)
        {
            imageList[i].GetComponent<Image>().sprite = image[i].GetComponent<Image>().sprite;
        }
    }

    public void Load()
    {
        Time.timeScale = 1;
        xml = GameObject.Find("Xml").GetComponent<XML>();
        xml.LoadByXml();        
        panelPause.SetActive(false);
       
        for (int i = 0; i <= 5; i++)
        {
            imageList[i].GetComponent<Image>().sprite = image[i].GetComponent<Image>().sprite;
        }
        

    }
    private void Update()
    {        
        Debug.Log(Time.timeScale);
        AttMoney();        
    }
    public void PanelOn()
    {
        
        if (!storePanel.activeInHierarchy)        
            storePanel.SetActive(true);
        else
            storePanel.SetActive(false);  
    }
    public void PlusEnergy(int quantity)
    {
        if(quant[0] != 0)
            status.energy += (quantity/2);
        if (quant[3] != 0)
            status.energy += quantity;
    }
    public void PlusHunger(int quantity)
    {
        if (quant[1] != 0)
            status.hunger += (quantity/2);
        if (quant[4] != 0)
            status.hunger += quantity;
    }
    public void PlusHealth(int quantity)
    {
        if (quant[2] != 0)
            status.health += (quantity/2);
        if (quant[5] != 0)
            status.health += quantity;
    }
    public void Plus(int i)
    {
        if (money != 0)
        {
            switch(i)
            {
                //energy
                case 0:                       
                    quant[i] += 1;
                    quantItem[i].text = "x" + quant[i].ToString();
                    money -= valorItem[i];                    
                    break;
                //hunger
                case 1:
                    quant[i] += 1;
                    quantItem[i].text = "x" + quant[i].ToString();
                    money -= valorItem[i];
                    break;
                //health
                case 2:
                    quant[i] += 1;
                    quantItem[i].text = "x" + quant[i].ToString();
                    money -= valorItem[i];
                    break;
                //energy
                case 3:
                    quant[i] += 1;
                    quantItem[i].text = "x" + quant[i].ToString();
                    money -= valorItem[i];
                    break;
                //hunger
                case 4:
                    quant[i] += 1;
                    quantItem[i].text = "x" + quant[i].ToString();
                    money -= valorItem[i];
                    break;
                //health
                case 5:
                    quant[i] += 1;
                    quantItem[i].text = "x" + quant[i].ToString();
                    money -= valorItem[i];
                    break;
            }
            
        }
        
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
    private void AttMoney()
    {        
        moneyText.text = money.ToString();        
    }
    public int GetMoney()
    {
        return money;
    }    
    public void SetMoney(int newMoney)
    {
        money = newMoney;
    }
    public float GetEnergy()
    {
        return status.energy;
    }
    public void SetEnergy(float energy)
    {
        status.energy = energy;
    }
    public float GetHunger()
    {
        return status.hunger;
    }
    public void SetHunger(float hunger)
    {
        status.hunger = hunger;
    }
    public float GetHealth()
    {
        return status.health;
    }
    public void SetHealth(float health)
    {
        status.health = health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XML : MonoBehaviour
{
    private PlayerMove player;
    public StoreManager store;
    [SerializeField] int multMoney;

    #region Creat XML
    XmlElement playerStatus, money, score, statusHealth, statusEnergy, statusHunger;
    #endregion
    public static XML instance;
    private void Awake()
    {        
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Update()
    {
        store = GameObject.Find("GameManager").GetComponent<StoreManager>();
        player = GameObject.Find("NewPlayer").GetComponent<PlayerMove>();               
    }
    public void SaveByXml(int dinero)
    {
        XmlDocument xmlDocument = new XmlDocument();
       
        XmlElement save = xmlDocument.CreateElement("Save");
        save.SetAttribute("Teste", "Teste1");

        
        playerStatus = xmlDocument.CreateElement("PlayerStatus");

        money = xmlDocument.CreateElement("Dinheiro");
        statusHealth = xmlDocument.CreateElement("Vida");
        statusEnergy = xmlDocument.CreateElement("Energia");
        statusHunger = xmlDocument.CreateElement("Fome");

        if (File.Exists("Android/data/com.DefaultCompany.PrOUJETO/files" + "/SaveData.xml"))
        {
            money.InnerText = dinero.ToString();
            Debug.Log("Saved Money");
        }
        else
            money.InnerText = store.GetMoney().ToString();
        statusHealth.InnerText = store.GetHealth().ToString();
        statusEnergy.InnerText = store.GetHealth().ToString();
        statusHunger.InnerText = store.GetHunger().ToString();
        Debug.Log(statusHealth.InnerText);
        Debug.Log(money.InnerText);
        playerStatus.AppendChild(money);
        playerStatus.AppendChild(statusHealth);
        playerStatus.AppendChild(statusEnergy);
        playerStatus.AppendChild(statusHunger);

        save.AppendChild(playerStatus);
        xmlDocument.AppendChild(save);
        
        xmlDocument.Save("Android/data/com.DefaultCompany.PrOUJETO/files" + "/SaveData.xml");
        if (File.Exists("Android/data/com.DefaultCompany.PrOUJETO/files" + "/SaveData.xml"))
        {
            Debug.Log("Documento criado");
        }
    }
    public void TransformScoreInMoney()
    {
        if (!File.Exists("Android/data/com.DefaultCompany.PrOUJETO/files" + "/SaveData.xml"))
        {
            Debug.Log("Não existe save");
            
        }
        else
        {
            int munny = store.GetMoney() + ((int)player.actualScore * multMoney);           
            Debug.Log(munny);
            SaveByXml(munny);            
        }        
    }
    public void LoadByXml()
    {
        if (File.Exists("Android/data/com.DefaultCompany.PrOUJETO/files" + "/SaveData.xml"))
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("Android/data/com.DefaultCompany.PrOUJETO/files" + "/SaveData.xml");

            XmlNodeList playerStatus = xmlDocument.GetElementsByTagName("PlayerStatus");
            XmlNodeList money = xmlDocument.GetElementsByTagName("Dinheiro");
            XmlNodeList statusHealth = xmlDocument.GetElementsByTagName("Vida");
            XmlNodeList statusEnergy = xmlDocument.GetElementsByTagName("Energia");
            XmlNodeList statusHunger = xmlDocument.GetElementsByTagName("Fome");

            store.SetMoney(int.Parse(money[0].InnerText));
            store.SetHealth(float.Parse(statusHealth[0].InnerText));
            store.SetEnergy(float.Parse(statusEnergy[0].InnerText));
            store.SetHunger(float.Parse(statusHunger[0].InnerText));
            
        }

    }
}

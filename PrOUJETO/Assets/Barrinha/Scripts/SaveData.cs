using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class SaveData : MonoBehaviour
{
    private PlayerMove player;
    public StoreManager store;
    [SerializeField] int multMoney;
   
    public static SaveData instance;
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
    public void Save()
    {        
        PlayerPrefs.SetInt("Money", store.GetMoney());        
        PlayerPrefs.SetFloat("Health", store.GetHealth());
        PlayerPrefs.SetFloat("Energy", store.GetEnergy());
        PlayerPrefs.SetFloat("Hunger", store.GetHunger());

        for(int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt("Item:" + i, store.GetItemQuant(i));
        }
        
    }
    public void TransformScoreInMoney()
    {
        int inGameMunny = PlayerPrefs.GetInt("Money") + (int)player.actualScore * multMoney;
        PlayerPrefs.SetInt("TotalMoney", inGameMunny);
        Debug.Log(PlayerPrefs.GetInt("TotalMoney"));
    }
    public void Load()
    {        
        store.SetMoney(PlayerPrefs.GetInt("TotalMoney"));
        store.SetHealth(PlayerPrefs.GetFloat("Health"));
        store.SetEnergy(PlayerPrefs.GetFloat("Energy"));
        store.SetHunger(PlayerPrefs.GetFloat("Hunger"));

        for (int i = 0; i < 6; i++)
        {
            store.SetItemQuant(PlayerPrefs.GetInt("Item:" + i), i);
        }
    }
    public void ResetValors()
    {
        store.SetMoney(0);
        store.SetHealth(100);
        store.SetEnergy(100);
        store.SetHunger(100);

        for (int i = 0; i < 6; i++)
        {
            store.SetItemQuant(PlayerPrefs.GetInt("Item:" + i), 0);
        }
    }

}

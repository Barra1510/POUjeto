using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    //Pou States
    public enum STATE {HUNGER, ENERGY, HEALTH, DEADCASE}
    public STATE myState;
    ///
    //[SerializeField] int currentState = 0;
    [Header("Definição de valores iniciais")]
    [Range(0,100)]
    public float health, energy, hunger;
    [Header("Definição de valores máximos")]
    [SerializeField] float maxHealth, maxEnergy, maxHunger;
    //multiplicador de tempo
    [Header("Multiplicador de Tempo")]
    [SerializeField] float multTimeHeath, multTimeEnergy, multTimeHunger;
    //decrementador de energia
    [Header("Decrementar Energia")]
    [SerializeField] int energyLoss;

    [SerializeField] ScreenTransition screen;

    void Start()
    {
        health = maxHealth;
        energy = maxEnergy;
        hunger = maxHunger;
    }
    void Update()
    {
        health -= Time.deltaTime * multTimeHeath;
        energy += Time.deltaTime * multTimeEnergy;
        hunger -= Time.deltaTime * multTimeHunger;

        if (health <= 0)
            health = 0;

        if (energy <= 0)
            energy = 0;

        if (hunger <= 0)
            hunger = 0;

        if(health >= maxHealth)
            health = maxHealth;

        if (energy >= maxEnergy)
            energy = maxEnergy;

        if (hunger >= maxHunger)
            hunger = maxHunger;

    }
    void State()
    {       
        switch (hunger)
        {
            case 0:
                myState = STATE.HUNGER;
                break;
        }
        switch (energy)
        {
            case 0:
                myState = STATE.ENERGY;
                break;
        }
        switch (health)
        {
            case 0:
                myState = STATE.HEALTH;
                break;
        }
        if(health == 0 && energy == 0 && hunger == 0)
        {
            myState = STATE.DEADCASE;
        }       
       
        //switch (currentState)
        //{
        //    case 1:
        //        myState = STATE.HUNGER;
        //        break;
        //    case 2:
        //        myState = STATE.ENERGY;
        //        break;
        //    case 3:
        //        myState = STATE.HEALTH;
        //        break;
        //    case 4:
        //        myState = STATE.DEADCASE;
        //        break;
        //}        

    }
    public void EnergyLoss()
    {
        energy -= energyLoss;
    }
    public void CheckEnergy()
    {
        if (energy >= 5)
        {
            screen.GoTo(2);
            EnergyLoss();
        }
        else
            Debug.Log("Falta energia");
    }
}
    


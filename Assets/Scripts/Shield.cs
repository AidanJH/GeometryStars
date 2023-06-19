using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    //Maximum Shield capacity
    public float maxShield;

    //Current shield value
    public float currentShield;
    //The rate that 
    public float energyDraw;
    public float rechargeRate;
    public float efficiency = 1f;

    void Start()
    {
        maxShield = 100f;
        currentShield = maxShield;
        energyDraw = 10f;
        rechargeRate = efficiency * energyDraw;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        currentShield -= damage;
    }


    public void Recharge(Generator generator){
        // if(generator.GetPower() >= energyDraw && currentShield < maxShield){
        //      generator.DrawPower(energyDraw);
        //      currentShield += rechargeRate;
        // }
    }
}

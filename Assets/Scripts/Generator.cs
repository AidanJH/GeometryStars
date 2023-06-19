using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public float regenRate;
    public float currentCapacity;
    public float maxCapacity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool TakeEnergy(float amount){
        if(currentCapacity >= amount){
            this.currentCapacity -= amount;
            return true;
        }
        return false;
    }

    void Generate(){
        if(currentCapacity <= maxCapacity){
            currentCapacity += regenRate;
        }
    }
}

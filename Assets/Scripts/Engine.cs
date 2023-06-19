using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float Acceleration {get; set;}
    public string engineName;
    public ParticleSystem engineParticle;
    public float RotationSpeed {get; set;}

    public Engine(float acceleration, float rotationSpeed){
        Acceleration = acceleration;
        RotationSpeed = rotationSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire(){
        //Create some kind of engine particle effect
    }


}

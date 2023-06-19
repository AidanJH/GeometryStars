using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    

    public void Initialize(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }


    //Logic for collision here


    //Have bullet delete after X amount of units
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private double maxHealth;
    private double health;

    public void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }

    public void Damage(double damage)
    {
        Debug.Log("I have " + health + " <3");
        this.health = this.health - damage;
    }
}

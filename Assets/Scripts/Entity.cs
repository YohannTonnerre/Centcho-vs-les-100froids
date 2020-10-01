using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private double maxHealth;
    private double health;

    private Animator animator;

    public virtual void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        /*Debug.Log(getHorizontal());
        Debug.Log(getVertical());*/
        animator.SetFloat("Horizontal", getHorizontal());
        animator.SetFloat("Vertical", getVertical());
        animator.SetFloat("Magnitude", getMagnitude());

        Debug.Log(getZindex());
        transform.position = new Vector3(transform.position.x, transform.position.y, getZindex());
    }

    private float getZindex()
    {
        return -1 * (1F / (1000F + transform.position.y));
    }

    public void Damage(double damage)
    {
        Debug.Log("I have " + health + " <3");
        this.health = this.health - damage;
    }

    public abstract float getHorizontal();

    public abstract float getVertical();

    public abstract float getMagnitude();
}

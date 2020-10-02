using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Entity
{
    public HealthBar healthBar;
	public Transform player;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
	private Vector2 movement;
    
    public override void Start()
    {
        base.Start();
        rb = this.GetComponent<Rigidbody2D>();
        InitHealthBar();
    }

    public override void Update()
    {
        base.Update();
        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        healthBar.SetValue(GetHealth());
    }

    private void FixedUpdate(){
    	moveCharacter(movement);
    }

    public void InitHealthBar()
    {
        healthBar.SetMax(GetMaxHealth());
    }

    void moveCharacter(Vector2 direction){
    	rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public override float getHorizontal()
    {
        return movement.x;
    }

    public override float getVertical()
    {
        return movement.y;
    }

    public override float getMagnitude()
    {
        return movement.magnitude;
    }

    public override void onDied()
    {
        Destroy(gameObject);
    }
}

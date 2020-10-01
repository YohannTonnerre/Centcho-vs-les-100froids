using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Entity
{
	public Transform player;
	private Rigidbody2D rb;
	public float moveSpeed = 5f;
	private Vector2 movement;


	public Animator animator;
	Animation myAnimation;
    // Start is called before the first frame update
    
    public override void Start()
    {
        base.Start();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;         
    }

    private void FixedUpdate(){
    	moveCharacter(movement);
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
}

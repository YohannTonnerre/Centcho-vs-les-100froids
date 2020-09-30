using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
	public Transform player;
	private Rigidbody2D rb;
	public float moveSpeed = 5f;
	private Vector2 movement;


	public Animator animator;



	Animation myAnimation;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {


    	animator.SetFloat("Horizontal", movement.x);
    	animator.SetFloat("Vertical", movement.y);
    	animator.SetFloat("Magnitude", movement.magnitude);
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
}

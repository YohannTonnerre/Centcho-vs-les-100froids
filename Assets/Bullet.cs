using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Gun gun;
    private float timeStart;

    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeStart > 5)
        {
            Destroy(gameObject);
        }
    }

    public void SetSource(Gun gun)
    {
        this.gun = gun;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            enemy.Damage(gun.getDamage());
        }
    }
}

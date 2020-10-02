using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    public Transform canon;
    public GameObject bulletsPrefab;

    public override void shoot()
    {
        Debug.Log("GUN");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        if (tryShoot())
        {
            base.shootAnimation();
            Debug.Log("GUN SHOOT");
            GameObject bulletInstance = Instantiate(bulletsPrefab, canon.position, Quaternion.identity);
            bulletInstance.GetComponent<Bullet>().SetSource(this);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce((mousePos - transform.position).normalized * 30000);
        }
    }
}

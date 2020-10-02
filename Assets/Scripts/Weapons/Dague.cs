using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dague : Weapon
{
    public override void shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (tryShoot())
        {
            base.shootAnimation();
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    /*Debug.Log(getDistance(hit.collider.transform.position));*/
                    if (getDistance(hit.collider.transform.position) < getReach())
                    {
                        Entity entity = hit.collider.GetComponent<Entity>();
                        entity.Damage(getDamage());
                    }
                }
            }
        }
    }
}
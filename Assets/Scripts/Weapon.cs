using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private double reach;
    [SerializeField] private int damage;
    [SerializeField] private double cooldown;

    public Transform aimTransform;
    public GameObject scopePrefab;
    private GameObject scopeInstance;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        scopeInstance = Instantiate(scopePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        scopeInstance.transform.position = getMousePosition3D();
        HandleAiming();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("SHOOT");
            shoot();
        }
    }

    public Vector3 getMousePosition3D()
    {
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        return mousePosition3d;
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = getMousePosition3D();

        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
    }

    public double getDistance(Vector2 gameObjectPosition)
    {
        return Vector2.Distance(gameObjectPosition, new Vector2(transform.position.x, transform.position.y));
    }

    public double getDamage()
    {
        return this.damage;
    }

    public double getReach()
    {
        return this.reach;
    }

    public abstract void shoot();


    public void shootAnimation(){


        animator.SetTrigger("Shoot");
        Debug.Log(animator);
            

    }
}

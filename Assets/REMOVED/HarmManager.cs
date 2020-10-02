using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmManager : MonoBehaviour
{
    public GameObject harmPrefab;

    public Vector3 harmRightFrontPosition;
    public Vector3 harmLeftFrontPosition;

    public Vector3 harmSidePosition;

    public Vector3 harmRightBackPosition;
    public Vector3 harmLeftBackPosition;

    private Vector3 harmRightPosition;
    private Vector3 harmLeftPosition;


    private GameObject harmRight;
    private GameObject harmLeft;


    // Start is called before the first frame update
    void Start()
    {
        harmRight = Instantiate(harmPrefab, new Vector3(0,0,0), Quaternion.identity);
        harmRight.transform.parent = transform;
        harmLeft = Instantiate(harmPrefab, new Vector3(0,0,0), Quaternion.identity);
        harmLeft.transform.parent = transform;

        setHarmOrder(1, 1);
        turnFront();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void setHarmOrder(int orderLeft, int orderRight)
    {
        harmLeft.GetComponent<SpriteRenderer>().sortingOrder = orderLeft;
        harmRight.GetComponent<SpriteRenderer>().sortingOrder = orderRight;
    }

    private void setHarmDirection(int left, int right)
    {
        harmLeft.transform.localScale = new Vector3(left, 1, 1);
        harmRight.transform.localScale = new Vector3(right, 1, 1);
    }

    public void turnLeft()
    {
        Debug.Log("turnLeft");

        harmRight.transform.localPosition = harmSidePosition;
        harmLeft.transform.localPosition = harmSidePosition;
        setHarmDirection(-1, -1);
        setHarmOrder(0, 1);
    }

    public void turnRight()
    {
        Debug.Log("turnRight");

        harmRight.transform.localPosition = harmSidePosition;
        harmLeft.transform.localPosition = harmSidePosition;
        setHarmDirection(1, 1);
        setHarmOrder(1, 0);
    }

    public void turnBack()
    {
        Debug.Log("turnBack");
        harmRight.transform.localPosition = harmRightBackPosition;
        harmLeft.transform.localPosition = harmLeftBackPosition;
        setHarmDirection(-1, 1);
        setHarmOrder(0, 0);
    }

    public void turnFront()
    {
        Debug.Log("turnFront");
        harmRight.transform.localPosition = harmRightFrontPosition;
        harmLeft.transform.localPosition = harmLeftFrontPosition;
        setHarmDirection(-1, 1);
        setHarmOrder(1, 1);
    }


    public void turn(float h, float v)
    {
        if (h == 1) turnRight();
        if (h == -1) turnLeft();
        if (v == -1) turnFront();
        if (v == 1) turnBack();
    }
}

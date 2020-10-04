using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject bar;
    private double max = 100;
    private double value;

    void Start()
    {
        this.value = 50;
    }

    void Update()
    {
        /*Debug.Log("FLOAT: " + (value / max));*/
        bar.transform.localScale = new Vector3((float)(value / max), 1, 1);
    }

    public void SetMax(double max)
    {
        this.max = max;
    }

    public double GetMax()
    {
        return this.max;
    }

    public void SetValue(double value)
    {
        this.value = value;
    }

    public double getValue()
    {
        return this.value;
    }
}

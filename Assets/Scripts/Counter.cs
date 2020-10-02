using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private int defaultValue;
    [SerializeField] private UnityEngine.UI.Text text;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        this.count = defaultValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            text.text = count.ToString();
        }
    }

    public void SetCount(int count)
    {
        this.count = count;
    }

    public int GetCount()
    {
        return this.count;
    }


}

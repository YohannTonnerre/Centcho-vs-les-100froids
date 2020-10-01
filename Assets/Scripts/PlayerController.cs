﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : Entity
{
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    private Vector3 _mousePosition;
    private Transform transform;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private int speed = 5;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        base.Update();
        GetPlayerInput();
        if (_verticalInput != 0 && _horizontalInput != 0)
        {
            transform.position += new Vector3(getHorizontalOffset(), getVerticalOffset(), 0) / Mathf.Sqrt(2);
        } else
        {
            transform.position += new Vector3(getHorizontalOffset(), getVerticalOffset(), 0);
        }
        
    }

    private float getVerticalOffset()
    {
        return _verticalInput * Time.deltaTime * speed;
    }
    private float getHorizontalOffset()
    {
        return _horizontalInput * Time.deltaTime * speed;
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        _mousePosition = new Vector3(mousePosition3d.x, mousePosition3d.y, 0);

    }

    public override float getHorizontal()
    {
        return _horizontalInput;
    }

    public override float getVertical()
    {
        return _verticalInput;
    }

    public override float getMagnitude()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f).magnitude;
    }
}
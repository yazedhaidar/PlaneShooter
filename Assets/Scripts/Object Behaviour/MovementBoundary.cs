using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MovementBoundary : MonoBehaviour
{
    public Rect Boundary;
    private Moveable moveable;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isXOutOfBoundary())
        {
            moveable.setXDirection(0f);
        }

        if(isYOutOfBoundary())
        {
            moveable.setYDirection(0f);
        }
    }

    private bool isXOutOfBoundary()
    {
        return moveable.getNextPosition().x < Boundary.xMin || moveable.getNextPosition().x > Boundary.xMax;
    }

    private bool isYOutOfBoundary()
    {
        return moveable.getNextPosition().y < Boundary.yMin || moveable.getNextPosition().y > Boundary.yMax;
    }



}

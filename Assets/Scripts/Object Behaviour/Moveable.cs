using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moveable : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
   public float frequency = 1.0f; // Speed of sine movement
    public float magnitude = 0.005f; // Size of sine movement    
    public bool zigzag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zigzag)
        {
           
            ZigzagupdatePosition();
        }
        else
        {
            updatePosition();
        }
      
    }

    private void updatePosition()
    {
        transform.position = getNextPosition();
    }

    public Vector3 getNextPosition()
    {
        return transform.position + newPosition();
    }

    public Vector3 newPosition ()
    {
        return (direction * Time.deltaTime * speed);
    }

    internal void setXDirection(float v)
    {
        direction.x = v;
    }

    internal void setYDirection(float v)
    {
        direction.y = v;
    }

    internal void setDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }

    public void setDirection(Vector3 value)
    {
        direction = value;
    }

    public void setDirection(Vector2 value)
    {
        direction.x = value.x;
        direction.y = value.y;
    }

    private void ZigzagupdatePosition()
    {
        transform.position = getNextPosition() + transform.right * Mathf.Sin(Time.time * frequency) * magnitude; ;
    }
}

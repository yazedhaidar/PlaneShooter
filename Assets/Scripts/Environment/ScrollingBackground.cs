
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
  
    public Transform[] Background;
    private Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
      
     
        direction = new Vector3(0,-1,0);
    }

    // Update is called once per frame
    void Update()
    {
        positionUpdate();
        checkPosition();
    }

    private void checkPosition()
    {
        if (Background[0].position.y <= -12f) 
        {
            moveToTop(0);
        }
        if (Background[1].position.y <= -12f)
        {
            moveToTop(1);
        }
    }

    private void moveToTop(int index)
    {
        float a;
        if (index == 0)
        {
     
            Background[0].position = Background[1].position + new Vector3(0, 12, 0);
        }
        else if (index == 1)
        {
            Background[1].position = Background[0].position + new Vector3(0, 12, 0);
        }
       
    }

    private void positionUpdate()
    {
        Background[0].position += direction * Time.deltaTime * speed;
        Background[1].position += direction * Time.deltaTime * speed;
    }

   
}

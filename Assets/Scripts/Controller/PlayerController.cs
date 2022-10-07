using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class PlayerController : MonoBehaviour
{
    public InputHandler inputHandler;
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
        
    }
    private void OnSetDirection(Vector2 Direction)
    {
        //Debug.Log("123" + Direction);
        moveable.setDirection(Direction);
    }
   

    private void OnEnable()
    {
        inputHandler.OnMoveAction += OnSetDirection;
    }

    private void OnDisable()
    {
        inputHandler.OnMoveAction -= OnSetDirection;
    }

}

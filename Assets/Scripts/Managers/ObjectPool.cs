using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int size;
    private static ObjectPool instance;
    public GameObject[] prefabs;
    [SerializeField] private List<PoolObject> poolObjects;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instantiateObjects();
    }

    private void instantiateObjects()
    {
        poolObjects = new List<PoolObject>();
        for (int i = 0; i < size; i++)
        {
            foreach(GameObject go in prefabs)
            {
                poolObjects.Add(Instantiate(go,transform).GetComponent<PoolObject>()); 
            }
        }
    }

    public PoolObject requestObject(PoolObjectType type)
    {
        foreach(PoolObject po in poolObjects)
        {
            if(po.type==type && !po.isActive())
            {
                return po;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static ObjectPool GetInstance()
    {
        return instance;
    }

    public void deactivateAllObjects()
    {
        foreach(PoolObject poo in poolObjects)
        {
            poo.deactivate();
        }
    }
}

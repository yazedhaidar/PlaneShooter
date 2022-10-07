using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public List<float> firerateModifiers;
    public PoolObjectType type;
    private float timer=0;

    private void Awake()
    {
        firerateModifiers = new List<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    internal void addFireRateModifier(float modifier)
    {
        firerateModifiers.Add(modifier);
    }
    internal void removeFireRateModifier(float modifier)
    {
        firerateModifiers.Remove(modifier);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0 ;
    }


    public void shoot()
    {
        if (timer == 0f)
        {
            //Debug.Log("Tembak");
            ObjectPool.GetInstance().requestObject(type).activate(transform.position,transform.rotation);
            timer = fireRate / getFireRateModifier();
        }
       
    }

    private float getFireRateModifier()
    {
        float mod = 1;
        foreach(float f in firerateModifiers)
        {
            mod += f;
        }

        return mod;
    }

    internal void clearModifier()
    {
        firerateModifiers.Clear();
    }
}

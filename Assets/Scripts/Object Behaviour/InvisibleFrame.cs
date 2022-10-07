using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleFrame : MonoBehaviour
{
    public float duration;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime < 0 ? 0 : timer - Time.deltaTime;
    }

    public void activate()
    {
        timer = duration;
        StartCoroutine(blinking());
        deactivateCollider();
    }
    private void activateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void deactivateCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    private IEnumerator blinking()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;
        Color blinkColor = defaultColor;
        blinkColor.a = 0.3f;

        while (timer > 0)
        {
            sr.color = blinkColor;
            yield return new WaitForSeconds(0.2f);
            sr.color = defaultColor;
            yield return new WaitForSeconds(0.2f);

        }
        sr.color = defaultColor;
        activateCollider();
    }

}

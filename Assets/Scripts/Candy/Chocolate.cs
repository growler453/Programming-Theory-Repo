using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Chocolate : Candy
{
    private float timer = 0f;

    protected override void DoAction()
    {
        GiveSugar(10);
    }

    private void OnTriggerEnter(Collider other)
    {
        DoAction();
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
        if (timer >= 5f) { Destroy(gameObject); }
        timer += Time.deltaTime;
    }
}

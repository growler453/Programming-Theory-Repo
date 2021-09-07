using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lollipop : Candy
{
    private float timer = 0f;

    protected override void DoAction()
    {
        GiveSugar(15);
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

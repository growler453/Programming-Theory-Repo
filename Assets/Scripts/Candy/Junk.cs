using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Junk : Candy
{
    private List<string> grossText = new List<string>(new string[] { "gross", "eww", "nasty" });
    private float timer = 0f;

    protected override void DoAction()
    {
        DisplayText(grossText[Random.Range(0, grossText.Count)]);
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

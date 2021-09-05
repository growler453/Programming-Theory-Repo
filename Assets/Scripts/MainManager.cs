using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public Color pickedColor { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PickRed()
    {
        pickedColor = Color.red;
    }

    public void PickGreen()
    {
        pickedColor = Color.green;
    }

    public void PickBlue()
    {
        pickedColor = Color.blue;
    }
}

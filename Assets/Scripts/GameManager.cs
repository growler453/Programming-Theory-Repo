using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text score;
    public static bool gameActive { get; private set; }
    private int sugarCount;

    private void StartGame()
    {
        gameActive = true;
        // After clicking start in title
    }

    public void IncreaseScore(int sugar)
    {
        sugarCount += sugar;
        score.text = "Sugar: " + sugarCount;
    }

    public void EndGame()
    {
        gameActive = false;
        // Back to title scene
    }
}

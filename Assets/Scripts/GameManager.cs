using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text score;
    public static bool gameActive { get; private set; }
    [SerializeField] GameObject startPrompt;
    [SerializeField] GameObject endScreen;
    private int sugarCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && startPrompt.activeSelf)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Space) && endScreen.activeSelf)
        {
            ReturnToTitle();
        }
    }

    private void StartGame()
    {
        gameActive = true;
        startPrompt.SetActive(false);
    }

    public void IncreaseScore(int sugar)
    {
        sugarCount += sugar;
        score.text = "Sugar: " + sugarCount;
    }

    public void EndGame()
    {
        gameActive = false;
        endScreen.SetActive(true);
    }

    private void ReturnToTitle()
    {
        SceneManager.LoadScene(1);
    }
}

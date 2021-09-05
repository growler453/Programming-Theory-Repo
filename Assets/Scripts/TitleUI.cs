using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] GameObject colorUI;
    [SerializeField] GameObject startUI;

    public void ShowColors()
    {
        startUI.SetActive(false);
        colorUI.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

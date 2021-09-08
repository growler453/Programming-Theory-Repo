using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// INHERITANCE BASE CLASS
public abstract class Candy : MonoBehaviour
{
    private Text popup;
    private List<string> candyText = new List<string>(new string[] { "yummy!", "sweet!", "tasty!" });
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        popup = GameObject.Find("Popup Text").GetComponent<Text>();
    }

    // ABSTRACTION

    // Increases score, sets text opacity and displays it
    protected void GiveSugar(int sugar)
    {
        gameManager.IncreaseScore(sugar);
        popup.text = candyText[Random.Range(0, candyText.Count)] + "\n+ " + sugar;
        popup.gameObject.SetActive(true);
        PopupTimer();
    }

    // Sets text opacity and displays it
    protected void DisplayText(string text)
    {
        gameManager.IncreaseScore(-10);
        popup.text = text + "\n- 10";
        popup.gameObject.SetActive(true);
        PopupTimer();
    }

    // POLYMORPHISM
    protected abstract void DoAction();

    // Displays text for set time or until it's opacity is zero
    protected IEnumerator PopupTimer()
    {
            yield return new WaitForSeconds(2f);
            popup.gameObject.SetActive(false);
    }

}

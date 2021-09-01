using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Candy : MonoBehaviour
{
    [SerializeField] Text popup;
    private Color popupAlpha;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Increases score, sets text opacity and displays it
    protected void GiveSugar(int sugar)
    {
        gameManager.IncreaseScore(sugar);
        popupAlpha.a = 255;
        popup.text = "+ " + sugar;
        popup.gameObject.SetActive(true);
        PickupTimer();
    }

    // Sets text opacity and displays it
    protected void DisplayText(string text)
    {
        popupAlpha.a = 255;
        popup.text = text;
        popup.gameObject.SetActive(true);
        PickupTimer();
    }

    protected abstract IEnumerator PickupTimer();

    // Displays text for set time or until it's opacity is zero
    protected IEnumerator PopupTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            popupAlpha.a -= Time.deltaTime * (10);
            popup.color = popupAlpha;
            if (popup.color.a <= 0)
            {
                popup.gameObject.SetActive(false);
                yield break;
            }
        }
    }

}

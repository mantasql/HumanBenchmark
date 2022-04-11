using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ReactionTimeGame : MonoBehaviour
{
    private Image buttonImage;
    private TMP_Text buttonText;
    
    private float reactionTime;
    private bool timerCanBeStopped, isGameRunning;

    void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
        buttonText = gameObject.GetComponentInChildren<TMP_Text>();

        isGameRunning = false;
        timerCanBeStopped = false;
        reactionTime = 0.0f;

        buttonText.text = "Click to Start";
        buttonImage.color = Color.white;
    }

    void Update()
    {
        if (timerCanBeStopped)
        {
            reactionTime += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        if (!isGameRunning)
        {
            isGameRunning = true;
            timerCanBeStopped = false;
            reactionTime = 0.0f;
            buttonText.text = "Wait for Green";
            buttonImage.color = Color.red;
            StartCoroutine(WaitForRandomTime());
        }
        else
        {
            isGameRunning = false;
            buttonImage.color = Color.white;

            if (timerCanBeStopped)
            {
                buttonText.text = "Reaction Time: " + Mathf.Round(reactionTime * 1000.0f) + " ms\nClick to Start";
            }
            else
            {
                buttonText.text = "Too Soon!\nClick to Start";
                StopAllCoroutines();
            }
        }
    }

    private IEnumerator WaitForRandomTime()
    {
        float waitTime = Random.Range(1.0f, 5.0f);
        yield return new WaitForSeconds(waitTime);

        timerCanBeStopped = true;
        buttonText.text = "Click!";
        buttonImage.color = Color.green;
    }
}

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

        buttonText.text = "Reaction Time Test\n\nWhen the red box turns green, click as quickly as you can\n\nClick anywhere to start";
        buttonImage.color = Color.white;
    }

    void Update()
    {
        if (timerCanBeStopped)
        {
            reactionTime += Time.deltaTime;
        }
    }

    public void OnClick()
    {
        if (!isGameRunning)
        {
            isGameRunning = true;
            timerCanBeStopped = false;
            reactionTime = 0.0f;
            buttonText.text = "...\nWait for green";
            buttonImage.color = Color.red;
            StartCoroutine(WaitForRandomTime());
        }
        else
        {
            isGameRunning = false;
            buttonImage.color = Color.white;

            if (timerCanBeStopped)
            {
                buttonText.text = "Reaction time: " + Mathf.Round(reactionTime * 1000.0f) + " ms\nClick to keep going";
            }
            else
            {
                buttonText.text = "Too soon!\nClick to try again";
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

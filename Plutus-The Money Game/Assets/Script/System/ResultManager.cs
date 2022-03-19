using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get; set; }

    public GameObject winUIObject;
    public GameObject winUIObject2;
    public GameObject loseUIObject;

    public GameObject earnEarn;

    public float waitTime;
    public int nextPlusScore, lastMinusScore;
    public int score, highScore;
    public bool isWin;
    public bool isResult, Lose;

    private float waitForSecs;

    public Animator lifeAnimation;
    public int numberOfLife;

    public int earnNumberAppear;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI qouteText;

    private void Awake()
    {
        Instance = this;
        scoreText.text = "";
        scoreText2.text = "";
        scoreText3.text = "";
        nextPlusScore = 100;
        waitForSecs = 0.5f;
    }

    private void Update()
    {
        scoreText.text = $"{score} pts";
        scoreText2.text = $"{score} pts";
        scoreText3.text = $"{score} pts";

        if (score < 0)
            score = 0;

        if (lastMinusScore < 0)
            lastMinusScore = 0;

        if (isResult)
        {
            if (isWin)
            {
                AddtoScorePoints();
            }
            else
            {
                isResult = false;
            }
        }
    }

    public IEnumerator WinResult()
    {
        winUIObject2.SetActive(true);
        isResult = true;

        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator LoseResult()
    {
        winUIObject.SetActive(true);
        RandomQuote();
        Life();
        isResult = true;

        yield return new WaitForSeconds(4f);
        StartCoroutine(BackToResult());
    }

    public IEnumerator BackToResult()
    {
        yield return new WaitForSeconds(0.5f);

        if (numberOfLife == 3)
        {
            loseUIObject.SetActive(true);
            winUIObject.SetActive(false);
            winUIObject2.SetActive(false);
        }
        else
        {
            Data.Instance.ChangeLevel();
            SpeedUpLevel();
            earnNumberAppear++;

            yield return new WaitForSeconds(waitForSecs);
            waitForSecs = 0.5f;
            earnEarn.SetActive(false);

            GameUIController.Instance.IntrctuctionsOpen();
            winUIObject.SetActive(false);
            winUIObject2.SetActive(false);
        }
    }

    public void Life()
    {
        numberOfLife++;

        switch (numberOfLife)
        {
            case 1:
                lifeAnimation.SetTrigger("minusHealth");
                break;
            case 2:
                lifeAnimation.SetTrigger("minusHealth_1");
                break;
            case 3:
                lifeAnimation.SetTrigger("minusHealth_2");
                break;
        }
    }

    public void SpeedUpLevel()
    {
        switch (earnNumberAppear)
        {
            case 5:
                earnEarn.SetActive(true);
                waitForSecs = 1f;
                UITimer.Instance.AddTimerSpeed();
                break;
            case 10:
                earnEarn.SetActive(true);
                waitForSecs = 1f;
                UITimer.Instance.AddTimerSpeed();
                break;
            case 15:
                earnEarn.SetActive(true);
                waitForSecs = 1f;
                UITimer.Instance.AddTimerSpeed();
                break;
        }
    }
    public void RandomQuote()
    {
        switch (Random.Range(0, 5))
        {
            case 0:
                qouteText.text = "Spend your money wisely.";
                break;
            case 1:
                qouteText.text = "Learn to manage your work and time.";
                break;
            case 2:
                qouteText.text = "MANAGE YOUR BUDGET:you can do this by identifying your wants and needs.";
                break;
            case 3:
                qouteText.text = "HAVE EMERGENCY FUNDS: typhoons and earthquakes can rid you of your food and home.";
                break;
            case 4:
                qouteText.text = "Save money for the future.";
                break;
        }
    }

    public void AddtoScorePoints()
    {
        score += 1;

        if (score >= nextPlusScore)
        {
            isResult = false;
            StartCoroutine(BackToResult());

            nextPlusScore += 100;
        }
    }

    public void MinustoScorePoints()
    {
        score += 1;

        if (score <= lastMinusScore)
        {
            isResult = false;

            lastMinusScore += 100;
        }
    }

    // public IEnumerator LoseResult()
    // {
    //     loseUIObject.SetActive(true);

    //     yield return new WaitForSeconds(0.5f);
    //     Data.Instance.ChangeLevel();

    //     yield return new WaitForSeconds(2f);

    //     GameUIController.Instance.IntrctuctionsOpen();
    //     loseUIObject.SetActive(false);
    // }
}

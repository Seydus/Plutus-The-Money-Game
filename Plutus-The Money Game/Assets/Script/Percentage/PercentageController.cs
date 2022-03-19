using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PercentageController : MonoBehaviour
{
    public static PercentageController Instance { get; set; }

    #region Components
    [Space]
    [Header("Components")]
    public Transform[] coins;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Slider timerSlider;
    #endregion

    #region Variables
    [Space]
    [Header("Percentage")]
    public float percent = 0f;
    public int[] randomValue = new int[3];
    public bool stopUpdate;

    private bool _getLevel;
    #endregion

    private int value;
    private void Awake()
    {
        Instance = this;
        ResetData();
    }

    private void Update()
    {
        if (!GameUIController.Instance.stopUpdate)
        {
            PercentageStatus();
        }

        if (gameObject != null && !_getLevel)
        {
            LevelNumber();
            _getLevel = false;
        }
        else
        {
            _getLevel = true;
        }
    }

    public void PercentageStatus()
    {
        if (timerSlider.value <= 0f)
        {
            switch (percent)
            {
                case 0:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                    ResultManager.Instance.isWin = false;
                    GameUIController.Instance.stopUpdate = true;
                    break;
                case 25f:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                    ResultManager.Instance.isWin = false;
                    GameUIController.Instance.stopUpdate = true;
                    break;
                case 50f:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                    ResultManager.Instance.isWin = true;
                    GameUIController.Instance.stopUpdate = true;
                    break;
                case 100f:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                    ResultManager.Instance.isWin = false;
                    GameUIController.Instance.stopUpdate = true;
                    break;
            }
        }
        else
        {
            switch (percent)
            {
                case 25f:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                    ResultManager.Instance.isWin = false;
                    GameUIController.Instance.stopUpdate = true;
                    break;
                case 50f:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                    ResultManager.Instance.isWin = true;
                    GameUIController.Instance.stopUpdate = true;
                    break;
                case 100f:
                    ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                    ResultManager.Instance.isWin = false;
                    GameUIController.Instance.stopUpdate = true;
                    break;
            }
        }
    }

    public void LevelNumber()
    {
        GameUIController.Instance.level = 3;
    }

    public void ResetData()
    {
        ScramblePercent();
    }

    public void ScramblePercent()
    {
        //Shuffles the index of an array
        Shuffle(randomValue);

        //Randomly selects and enables letter gameObject
        for (int i = 0; i < randomValue.Length; i++)
        {
            coins[i].SetSiblingIndex(randomValue[i]);
        }
    }

    public void Shuffle(int[] a)
    {
        for (int i = a.Length - 1; i > 0; i--)
        {
            int random = Random.Range(0, i);

            int temp = a[i];

            a[i] = a[random];
            a[random] = temp;
        }
    }
}

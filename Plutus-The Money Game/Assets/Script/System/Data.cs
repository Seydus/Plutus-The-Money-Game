using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour
{
    public static Data Instance { get; set; }

    [Space]
    [Header("Components")]
    public GameObject[] game;
    public GameObject budget;
    public PercentageController percentage;
    public SpellingController spelling;

    public GameObject[] percentObject;
    public Transform[] percentPosition;

    [Space]
    [SerializeField] private Slider timerSlider;
    [SerializeField] private Slider sliderProgress;
    [SerializeField] private TextMeshProUGUI statusText;

    [Space]
    [Header("Variables")]
    private int value;

    private void Awake()
    {
        Instance = this;
        
    }

    void Start()
    {
        Shuffle.ShuffleObject(game);
        Status();
    }

    void Update()
    {
        //if (Input.GetKeyDown("w"))
        //{
        //    ChangeLevel();
        //}
    }

    public void ChangeLevel()
    {
        Shuffle.ShuffleObject(game);
        Status();

        ResetData();

        BudgetData();
        BananaQueData();

        StartCoroutine(SpellingData());
    }

    private void Status()
    {
        //Turning off all the gameObjects except for the given number
        for (int i = 0; i < game.Length; i++)
        {
            game[i].SetActive(i == value);
        }
    }

    private void BudgetData()
    {
        //if budgetcontroller object is active then execute
        if (budget.activeSelf)
        {
            BudgetController.Instance.BudgetData();
        }
    }

    private void BananaQueData()
    {
        percentage.ResetData();
    }

    public IEnumerator SpellingData()
    {
        if (spelling != null)
        {
            spelling.ResetSelectedValue();

            yield return new WaitForSeconds(0.2f);

            spelling.ResetSpellingData();
        }
    }

    private void ResetData()
    {
        timerSlider.value = 1;
        sliderProgress.value = 0;
    }
}

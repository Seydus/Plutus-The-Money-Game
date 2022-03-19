using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BudgetController : MonoBehaviour
{
    public static BudgetController Instance { get; set; }

    #region Components
    [Space]
    [Header("Components")]
    [SerializeField] private GameObject[] item;
    [SerializeField] private GameObject basket;
    #endregion

    #region UI
    [Space]
    [Header("Heads-up Display")]
    [SerializeField] private TextMeshProUGUI budgetText;
    [SerializeField] private TextMeshProUGUI totalText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Slider timerSlider;
    #endregion

    #region Variables
    [Space]
    [Header("Expenses")]
    public float budget = 0f;
    public float total;

    private bool _getLevel;
    #endregion

    private void Awake()
    {
        Instance = this;

        #region Random Generator
        RandomBudgetGenerator();
        InstantiateRandomItem();
        #endregion
    }

    private void Update()
    {
        if (!GameUIController.Instance.stopUpdate)
        {
            BudgetStatus();

            if (Input.GetKeyDown("s"))
            {
                BudgetData();
            }
        }

        if(gameObject != null && !_getLevel)
        {
            LevelNumber();
            _getLevel = false;
        }
        else
        {
            _getLevel = true;
        }
    }

    public void BudgetStatus()
    {
        budgetText.text = $"Budget: {budget} ₱";
        totalText.text = $"TOTAL: {total} ₱";

        if (timerSlider.value <= 0f)
        {
            if (total <= budget && total > 0f)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                ResultManager.Instance.isWin = true;
                GameUIController.Instance.stopUpdate = true;
            }
            else if (total <= 0f)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                ResultManager.Instance.isWin = false;
                GameUIController.Instance.stopUpdate = true;
            }
            else
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                ResultManager.Instance.isWin = false;
                GameUIController.Instance.stopUpdate = true;
            }
        }
        else
        {
            if (total <= budget && total > 0f)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                ResultManager.Instance.isWin = true;
                GameUIController.Instance.stopUpdate = true;
            }
        }
    }

    public void InstantiateRandomItem()
    {
        for (int i = 0; i < item.Length; i++)
        {
            Vector2 randomPos = new Vector2(basket.transform.position.x, basket.transform.position.y) + Random.insideUnitCircle * 1.7f;

            item[i].transform.position = randomPos;
        }
    }

    public void RandomBudgetGenerator()
    {
        budget = Random.Range(3, 10);
    }

    public void BudgetData()
    {
        RandomBudgetGenerator();
        InstantiateRandomItem();
    }

    public void LevelNumber()
    {
        GameUIController.Instance.level = 1;
    }
}
